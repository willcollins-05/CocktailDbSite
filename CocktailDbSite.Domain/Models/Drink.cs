using CocktailDbSite.Domain.Models.DrinkModels;

namespace CocktailDbSite.Domain.Models;

public class Drink
{
    public int Id { get; set; } = -1;
    public string Name { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new List<string>();
    public string VideoUrl { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool IsAlcoholic { get; set; } = false;
    public string Glass { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string DrinkThumbnailUrl { get; set; } = string.Empty;
    public List<string> Ingredients { get; set; } = new List<string>();
    public List<Measurement> Measurements { get; set; } = new List<Measurement>();
    public string DrinkImageUrl { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Drink: [Id: {Id}, Name: {Name}, Tags: {Tags}, VideoUrl: {VideoUrl}, Category: {Category} " +
            $"IsAlcoholic: {IsAlcoholic}, Glass: {Glass}, Instructions: {Instructions}," +
            $" DrinkThumbnailUrl: {DrinkThumbnailUrl}, Ingredients: {Ingredients}, Measurements: {Measurements}," +
            $" DrinkImageUrl: {DrinkImageUrl}]";
    }
}