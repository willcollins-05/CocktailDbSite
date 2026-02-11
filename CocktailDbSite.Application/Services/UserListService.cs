using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Domain.Models.UserLists;
using CocktailDbSite.Infrastructure.Repositories;

namespace CocktailDbSite.Application.Services;

public class UserListService
{
    private readonly IUserListRepository<UserList> _userListRepository;
    
    public UserListService(IUserListRepository<UserList> userListUserListRepository)
    {
        _userListRepository = userListUserListRepository;
    }

    public async Task AddNewUserList(UserList userList)
    {
        await _userListRepository.AddAsync(userList);
        await _userListRepository.SaveChangesAsync();
    }

    public async Task<List<UserList>> GetAllUserLists()
    {
        return await _userListRepository.ListAsync();
    }

    public async Task<List<UserList>> GetAllUserListsByApplicationUserId(string applicationUserId)
    {
        return await _userListRepository.GetAllFromApplicationUserId(applicationUserId);
    }

    public async Task<bool> ApplicationUserIdAndDrinkIdExists(string applicationUserId, int drinkId)
    {
        return await _userListRepository.ApplicationUserIdAndDrinkIdExists(applicationUserId, drinkId);
    }

    public async Task<UserList> GetFromApplicationUserIdAndDrinkId(string applicationUserId, int drinkId)
    {
        return await _userListRepository.GetFromApplicationUserIdAndDrinkId(applicationUserId, drinkId);
    }
    
    public async Task UpdateUserList(UserList userList)
    {
        _userListRepository.Update(userList);
        await _userListRepository.SaveChangesAsync();
    }

    public async Task DeleteUserListById(int listId)
    {
        await _userListRepository.DeleteDrinkById(listId);
        await _userListRepository.SaveChangesAsync();
    }
}