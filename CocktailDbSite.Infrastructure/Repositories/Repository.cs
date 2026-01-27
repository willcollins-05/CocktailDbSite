using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CocktailDbSite.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CocktailDbContext _context;

    private readonly DbSet<T> _dbSet;

    public Repository(CocktailDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    } 
    
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<List<T>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}