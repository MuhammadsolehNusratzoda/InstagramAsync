
using Domain.Models;
using Infrastructure.Services;

UserService userService = new();
User user = new User
{
    UserId = 11,
    Username = "Maga",
    Email = "nusratzoda@gmail.com",
    FullName = "Muhammadsoleh Nusratzoda"
};
await userService.AddUserAsync(user);
await userService.DeleteUserAsync(10);