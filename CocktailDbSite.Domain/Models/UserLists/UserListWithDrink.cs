namespace CocktailDbSite.Domain.Models.UserLists;

public class UserListWithDrink
{
    public int ListId { get; set; }
    public int Quantity { get; set; }
    public Drink? Drink { get; set; }
}