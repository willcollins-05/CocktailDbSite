using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Domain.Models;
using CocktailDbSite.Domain.Models.DrinkModels;
using CocktailDbSite.Domain.Models.WebpageModels;
using Newtonsoft.Json.Linq;

namespace CocktailDbSite.Domain.Services;

public class CocktailDbService : ICocktailProvider
{
    private readonly string _baseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";
    private readonly HttpClient _httpClient;

    public CocktailDbService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<HomepageDrinkLists?> GetHomepageDrinkLists()
    {
        var alcoholicDrinksUrl = $"{_baseUrl}filter.php?a=Alcoholic";
        var nonAlcoholicDrinksUrl = $"{_baseUrl}filter.php?a=Non_Alcoholic";

        try
        {
            var alcoholicResponse = await _httpClient.GetAsync(alcoholicDrinksUrl);
            var nonAlcoholicResponse = await _httpClient.GetAsync(nonAlcoholicDrinksUrl);

            if (!alcoholicResponse.IsSuccessStatusCode || !nonAlcoholicResponse.IsSuccessStatusCode) return null;

            var alcoholicResponseJsonString = await alcoholicResponse.Content.ReadAsStringAsync();
            var nonAlcoholicResponseJsonString = await nonAlcoholicResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(alcoholicResponseJsonString)) return null;
            if (string.IsNullOrWhiteSpace(nonAlcoholicResponseJsonString)) return null;

            var alcoholicJson = JObject.Parse(alcoholicResponseJsonString)["drinks"];
            var nonAlcoholicJson = JObject.Parse(nonAlcoholicResponseJsonString)["drinks"];

            var homepageDrinks = new HomepageDrinkLists();

            foreach (var alcoholicDrink in alcoholicJson)
            {
                var drink = new Drink();
                drink.Name = alcoholicDrink["strDrink"]?.ToString() ?? string.Empty;
                drink.DrinkThumbnailUrl = alcoholicDrink["strDrinkThumb"]?.ToString() ?? string.Empty;
                drink.Id = int.Parse(alcoholicDrink["idDrink"]?.ToString() ?? "-1");
                homepageDrinks.AlcoholicDrinks.Add(drink);
            }

            foreach (var nonAlcoholicDrink in nonAlcoholicJson)
            {
                var drink = new Drink();
                drink.Name = nonAlcoholicDrink["strDrink"]?.ToString() ?? string.Empty;
                drink.DrinkThumbnailUrl = nonAlcoholicDrink["strDrinkThumb"]?.ToString() ?? string.Empty;
                drink.Id = int.Parse(nonAlcoholicDrink["idDrink"]?.ToString() ?? "-1");
                homepageDrinks.NonAlcoholicDrinks.Add(drink);
            }

            return homepageDrinks;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Drink?> GetDrinkById(int id)
    {
        var lookupByIdUrl = $"{_baseUrl}lookup.php?i={id}";

        try
        {
            var lookupResponse = await _httpClient.GetAsync(lookupByIdUrl);

            if (!lookupResponse.IsSuccessStatusCode) return null;

            var lookupResponseJsonString = await lookupResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(lookupResponseJsonString)) return null;

            var lookupResponseJson = JObject.Parse(lookupResponseJsonString)["drinks"]?[0] ?? null;

            if (lookupResponseJson == null) return null;

            var drink = new Drink()
            {
                Id = int.Parse(lookupResponseJson["idDrink"]?.ToString() ?? "-1"),
                Name = lookupResponseJson["strDrink"]?.ToString() ?? string.Empty,
                Tags = (lookupResponseJson["strTags"]?.ToString() ?? string.Empty).Trim().Split(',').ToList(),
                VideoUrl = lookupResponseJson["strVideo"]?.ToString() ?? string.Empty,
                Category = lookupResponseJson["strCategory"]?.ToString() ?? string.Empty,
                IsAlcoholic = (lookupResponseJson["strAlcoholic"]?.ToString() ?? "NonAlcoholic") == "Alcoholic",
                Glass = lookupResponseJson["strGlass"]?.ToString() ?? string.Empty,
                DrinkThumbnailUrl = lookupResponseJson["strDrinkThumb"]?.ToString() ?? string.Empty,
                DrinkImageUrl = lookupResponseJson["strImageSource"]?.ToString() ?? string.Empty,
                Instructions = lookupResponseJson["strInstructions"]?.ToString() ?? string.Empty,
            };

            for (int i = 1; i <= 15; i++)
            {
                var ingredient = lookupResponseJson[$"strIngredient{i}"]?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(ingredient)) break;
                drink.Ingredients.Add(ingredient);
            }

            for (int i = 1; i <= 15; i++)
            {
                var measurement = lookupResponseJson[$"strMeasure{i}"]?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(measurement)) break;
                drink.Measurements.Add(Measurement.StringToMeasurementConvertion(measurement) ?? new Measurement());
            }

            return drink;
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<Drink>?> GetDrinksByName(string name)
    {
        var lookupByNameUrl = $"{_baseUrl}search.php?s={name}";

        try
        {
            var lookupResponse = await _httpClient.GetAsync(lookupByNameUrl);

            if (!lookupResponse.IsSuccessStatusCode) return null;

            var lookupResponseJsonString = await lookupResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(lookupResponseJsonString)) return null;

            var origin = JObject.Parse(lookupResponseJsonString);
            
            var drinkArray = origin["drinks"];
            
            if (drinkArray == null) return null;
            
            List<Drink> drinks = new List<Drink>();

            foreach (var drinkJson in drinkArray)
            {
                var drink = new Drink()
                {
                    Id = int.Parse(drinkJson["idDrink"]?.ToString() ?? "-1"),
                    Name = drinkJson["strDrink"]?.ToString() ?? string.Empty,
                    Tags = (drinkJson["strTags"]?.ToString() ?? string.Empty).Trim().Split(',').ToList(),
                    VideoUrl = drinkJson["strVideo"]?.ToString() ?? string.Empty,
                    Category = drinkJson["strCategory"]?.ToString() ?? string.Empty,
                    IsAlcoholic = (drinkJson["strAlcoholic"]?.ToString() ?? "NonAlcoholic") == "Alcoholic",
                    Glass = drinkJson["strGlass"]?.ToString() ?? string.Empty,
                    DrinkThumbnailUrl = drinkJson["strDrinkThumb"]?.ToString() ?? string.Empty,
                    DrinkImageUrl = drinkJson["strImageSource"]?.ToString() ?? string.Empty,
                    Instructions = drinkJson["strInstructions"]?.ToString() ?? string.Empty,
                };

                for (int i = 1; i <= 15; i++)
                {
                    var ingredient = drinkJson[$"strIngredient{i}"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(ingredient)) break;
                    drink.Ingredients.Add(ingredient);
                }

                for (int i = 1; i <= 15; i++)
                {
                    var measurement = drinkJson[$"strMeasure{i}"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(measurement)) break;
                    drink.Measurements.Add(Measurement.StringToMeasurementConvertion(measurement) ?? new Measurement());
                }
                
                drinks.Add(drink);
            }

            return drinks;
        }
        catch
        {
            return null;
        }
    }
}