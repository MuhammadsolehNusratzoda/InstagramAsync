using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _context = new();
    public async Task AddCommentAsync(Comment comment)
    {
        using var conn = _context.Connect();
        var sql = @"insert into Comments (CommentId, UserId, PostId, Content, CreationDate) values (@CommentId, @UserId, @PostId, @Content, @CreationDate)";
        await conn.ExecuteAsync(sql, comment);
    }


    public async Task DeleteCommentAsync(int commentId)
    {
        using var conn = _context.Connect();
        var sql = @"delete from Comments where CommentId = @commentId";
        await conn.ExecuteAsync(sql, new { Id = commentId });
    }

  
    public async Task<List<Comment>> GetCommentsOfPostsAsync(int postId)
    {
        using var conn = _context.Connect();
        var sql = @"select * from Comments where PostId = @PostId order by CreationDate desc";
        return await conn.QueryAsync<Comment>(sql, new { PostId = postId }).ToList();
    }

}
