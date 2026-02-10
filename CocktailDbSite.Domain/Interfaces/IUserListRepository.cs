namespace CocktailDbSite.Domain.Interfaces;

public interface IUserListRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task<List<T>> ListAsync();

    Task<T?> GetByIdAsync(int id);

    void Update(T entity);

    Task SaveChangesAsync();
    Task<List<T>> GetAllFromApplicationUserId(string applicationUserId);

    Task<T> GetFromApplicationUserIdAndDrinkId(string applicationUserId, int drinkId);

    Task<bool> ApplicationUserIdAndDrinkIdExists(string applicationUserId, int drinkId);
}