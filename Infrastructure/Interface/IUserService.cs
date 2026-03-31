using Domain.Models;

namespace Infrastructure.Interface;

public interface IUserService
{
    Task AddUserAsync(User user);
    Task<User> GetUserAsync(int userId);
    Task<List<User>> GetUsersAsync();
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
}
