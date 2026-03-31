using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class LikeService : ILikeService
{
    private readonly ApplicationDbContext _context = new();
    
    public async Task AddLikeAsync(Like like)
    {
        using var conn = _context.Connect();
        var sql = @"insert into Likes (LikeId, UserId, PostId, LikeDate) values (@LikeId, @UserId, @PostId, @LikeDate)";
        await conn.ExecuteAsync(sql, like);
        await conn.ExecuteAsync("update Posts set LikesCount = LikesCount + 1 WHERE PostId = @PostId", new { like.PostId });
    }

    public async Task DeleteLikeAsync(Like like)
    {
        using var conn = _context.Connect();
        var sql = @"delete from Likes where UserId = @UserId and PostId = @PostId";
        await conn.ExecuteAsync(sql, like);
        await conn.ExecuteAsync("update Posts set LikesCount = LikesCount - 1 where PostId = @PostId", new { like.PostId });
    }

    public async Task<List<Like>> GetLikesOfPostAsync(int postId)
    {
        using var conn = _context.Connect();
        var sql = "select * from Likes";
        var asc = await conn.QueryAsync<Like>(sql);
        return asc.ToList();
    }
}
