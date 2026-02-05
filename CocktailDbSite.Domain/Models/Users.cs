using System.ComponentModel.DataAnnotations;


namespace CocktailDbSite.Domain.Models;


public class Users
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

}