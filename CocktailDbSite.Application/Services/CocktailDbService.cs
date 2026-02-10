using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Domain.Models;
using CocktailDbSite.Domain.Models.WebpageModels;

namespace CocktailDbSite.Application.Services;

public class CocktailDbService
{
    private readonly ICocktailProvider _cocktailApi;

    public CocktailDbService(ICocktailProvider cocktailApi)
    {
        _cocktailApi = cocktailApi;
    }

    public async Task<HomepageDrinkLists?> GetHomepageDrinksAsync()
    {
        return await _cocktailApi.GetHomepageDrinkLists();
    }

    public async Task<Drink?> GetDrinkById(int id)
    {
        return await _cocktailApi.GetDrinkById(id);
    }

    public async Task<HomepageDrinkLists> GetDrinksByName(string name)
    {
        List<Drink>? drinks = await _cocktailApi.GetDrinksByName(name);


       
        if (drinks != null)
        {
            foreach (Drink drink in drinks)
            {
                Console.WriteLine($"{drink.Name} , is alchoholic {drink.IsAlcoholic}");
            }
        }
        
        
        
        HomepageDrinkLists homepageDrinkLists = new HomepageDrinkLists();

        if (drinks != null)
        {
            homepageDrinkLists.AlcoholicDrinks = drinks!.Where(d => d.IsAlcoholic).ToList();
            homepageDrinkLists.NonAlcoholicDrinks = drinks!.Where(d => !d.IsAlcoholic).ToList();
        }

        
        
        return homepageDrinkLists;
    }
}