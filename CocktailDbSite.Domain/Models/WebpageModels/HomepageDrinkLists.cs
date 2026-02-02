namespace CocktailDbSite.Domain.Models.WebpageModels;

public class HomepageDrinkLists
{
    public List<Drink> AlcoholicDrinks { get; set; } = new List<Drink>();
    public List<Drink> NonAlcoholicDrinks { get; set; } = new List<Drink>();
}