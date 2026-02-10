using CocktailDbSite.Domain.Identity;

namespace CocktailDbSite.Domain.Models.UserLists;

public class UserList
{
    public int Id { get; set; }
    public int CocktailDbId { get; set; }
    public string ApplicationUserId { get; set; }
    public int Quantity { get; set; }
}