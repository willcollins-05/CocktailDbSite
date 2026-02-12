using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CocktailDbSite.Infrastructure.Data;

public class CocktailDbContextFactory : IDesignTimeDbContextFactory<CocktailDbContext>
{
    //NOTE: THIS IS ONLY USED FOR CLI COMMANDS.
    public CocktailDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CocktailDbContext>();

        // optionsBuilder.UseNpgsql(/* ADD CONNECTION STRING HERE IF RUNNING MIGRATIONS */);
        var connectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:POSTGRESQLCONNSTR_DefaultConnection");
        }
        
        optionsBuilder.UseNpgsql(connectionString);
        
        optionsBuilder.UseOpenIddict();
        
        return new CocktailDbContext(optionsBuilder.Options);
    }
}