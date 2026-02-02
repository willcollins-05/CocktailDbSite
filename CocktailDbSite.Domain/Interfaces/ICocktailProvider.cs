using CocktailDbSite.Domain.Models;
using CocktailDbSite.Domain.Models.WebpageModels;

namespace CocktailDbSite.Domain.Interfaces;

public interface ICocktailProvider
{
    public Task<HomepageDrinkLists?> GetHomepageDrinkLists();

    public Task<Drink?> GetDrinkById(int id);

    public Task<List<Drink>?> GetDrinksByName(string name);
}