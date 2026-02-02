using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Domain.Services;
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
        services.AddHttpClient<ICocktailProvider, CocktailDbService>();
        return services;
    }
}