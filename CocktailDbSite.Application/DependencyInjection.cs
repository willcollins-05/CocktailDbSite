using CocktailDbSite.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CocktailDbSite.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserListService>();
        services.AddScoped<CocktailDbService>();
        return services;
    }
    
}