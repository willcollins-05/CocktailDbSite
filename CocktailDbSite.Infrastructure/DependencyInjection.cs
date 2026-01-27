using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Infrastructure.Data;
using CocktailDbSite.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CocktailDbSite.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CocktailDbContext>(o => o.UseNpgsql(configuration["CONNECTION_STRING"]));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        //TODO: Add services.AddHttpClient<Interface, Service>() for the CocktailDB API
        return services;
    }
}