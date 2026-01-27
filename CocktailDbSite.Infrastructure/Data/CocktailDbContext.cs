using CocktailDbSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CocktailDbSite.Infrastructure.Data;

public class CocktailDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public CocktailDbContext(DbContextOptions options) : base(options)
    {
    }
    
    // DbSet<T>
    public DbSet<TestTable> TestTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration["CONNECTION_STRING"];
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}