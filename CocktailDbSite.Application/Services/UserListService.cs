using CocktailDbSite.Domain.Interfaces;
using CocktailDbSite.Domain.Models.UserLists;
using CocktailDbSite.Infrastructure.Repositories;

namespace CocktailDbSite.Application.Services;

public class UserListService
{
    private readonly IUserListRepository<UserList> _userListUserListRepository;
    
    public UserListService(IUserListRepository<UserList> userListUserListRepository)
    {
        _userListUserListRepository = userListUserListRepository;
    }

    public async Task AddNewUserList(UserList userList)
    {
        await _userListUserListRepository.AddAsync(userList);
        await _userListUserListRepository.SaveChangesAsync();
    }

    public async Task<List<UserList>> GetAllUserLists()
    {
        return await _userListUserListRepository.ListAsync();
    }

    public async Task<List<UserList>> GetAllUserListsByApplicationUserId(string applicationUserId)
    {
        return await _userListUserListRepository.GetAllFromApplicationUserId(applicationUserId);
    }

    public async Task<bool> ApplicationUserIdAndDrinkIdExists(string applicationUserId, int drinkId)
    {
        return await _userListUserListRepository.ApplicationUserIdAndDrinkIdExists(applicationUserId, drinkId);
    }

    public async Task<UserList> GetFromApplicationUserIdAndDrinkId(string applicationUserId, int drinkId)
    {
        return await _userListUserListRepository.GetFromApplicationUserIdAndDrinkId(applicationUserId, drinkId);
    }
    
    public async Task UpdateUserList(UserList userList)
    {
        _userListUserListRepository.Update(userList);
        await _userListUserListRepository.SaveChangesAsync();
    }
}