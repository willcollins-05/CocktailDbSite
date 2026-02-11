using CocktailDbSite.Application.Services;
using CocktailDbSite.Application.Services.WebpageServices;
using Microsoft.Extensions.DependencyInjection;

namespace CocktailDbSite.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserListService>();
        services.AddScoped<CocktailDbService>();
        services.AddScoped<ToastService>();
        return services;
    }
    
}