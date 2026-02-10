using CocktailDbSite.Domain.Identity;
using CocktailDbSite.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CocktailDbSite.Infrastructure.Data;

public class CocktailDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    private readonly IConfiguration _configuration;
    
    public CocktailDbContext(DbContextOptions options) : base(options)
    {
    }
    
    // DbSet<T>
    public DbSet<TestTable> TestTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationRole>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration["CONNECTION_STRING"];
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}