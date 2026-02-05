using CocktailDbSite.Domain.Identity;
using CocktailDbSite.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CocktailDbSite.Infrastructure.Data;

public class CocktailDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public CocktailDbContext(DbContextOptions options) : base(options)
    {
    }
    
    // DbSet<T>
    public DbSet<TestTable> TestTables { get; set; }
    public DbSet<Users> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}