using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context = new();
    public async Task AddUserAsync(User user)
    {
        using var connection = _context.Connect();
        var sqlQuery = @$"insert into Users(UserId,Username,Email,FullName)values(@userid,@username,@email,@fullname)";
        await connection.ExecuteAsync(sqlQuery,new{user.UserId,user.Username,user.Email,user.FullName});
    }

    public async Task DeleteUserAsync(int userId)
    {
        using var connection = _context.Connect();
        var sqlQuery = @$"delete from Users where userid = @userid";
        await connection.ExecuteAsync(sqlQuery,new{userId});
    }

    public async Task<User> GetUserAsync(int userId)
    {
        using var connection = _context.Connect();
        var sqlQuery = @$"select * from Users where userid = @userid";
        return await connection.QueryFirstOrDefaultAsync<User>(sqlQuery, new{userId})??new User();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        using var conn = _context.Connect();
        var sql = "select * from users";
        var ans =  await conn.QueryAsync<User>(sql);  
        return ans.ToList();
    }

    public async Task UpdateUserAsync(User user)
    {
        using var conn = _context.Connect();
        var query = "update users set Username=@username,Fullname=@fullname, Email=@email,Userid=@userid where UserId=@userid";
        await conn.ExecuteAsync(query, new {user.Username,user.FullName, user.Email, user.UserId}); 
    }
    
}
