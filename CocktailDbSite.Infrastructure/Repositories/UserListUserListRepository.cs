using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Domain.Models.UserLists;
using CocktailDbSite.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CocktailDbSite.Infrastructure.Repositories;

public class UserListUserListRepository<T> : IUserListRepository<T> where T : UserList
{
    private readonly CocktailDbContext _context;

    private readonly DbSet<T> _dbSet;

    public UserListUserListRepository(CocktailDbContext context)
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

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllFromApplicationUserId(string applicationUserId)
    {
        return await _dbSet.Where(u => u.ApplicationUserId == applicationUserId)
            .ToListAsync();
    }

    public async Task<T> GetFromApplicationUserIdAndDrinkId(string applicationUserId, int drinkId)
    {
        return await _dbSet.Where(u => u.ApplicationUserId == applicationUserId)
            .Where(u => u.CocktailDbId == drinkId)
            .FirstAsync();
    }

    public async Task<bool> ApplicationUserIdAndDrinkIdExists(string applicationUserId, int drinkId)
    {
        return await _dbSet.Where(u => u.ApplicationUserId == applicationUserId)
            .Where(u => u.CocktailDbId == drinkId)
            .AnyAsync();
    }

    public async Task DeleteDrink(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task DeleteDrinkById(int listId)
    {
        await _dbSet.Where(u => u.Id == listId)
            .ExecuteDeleteAsync();
    }
}