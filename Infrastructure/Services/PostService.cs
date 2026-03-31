using System.Threading.Tasks;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _context = new();

    public async Task AddPostAsync(Post post)
    {
        using var conn = _context.Connect();
        await conn.ExecuteAsync(@"insert into posts (PostId, UserId, Content, CreationDate, LikesCount) values (@PostId, @UserId, @Content, @CreationDate, @LikesCount)", post);
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        using var conn = _context.Connect();
        var sql = "select * from Posts";
        var asc = await conn.QueryAsync<Post>(sql);
        return asc.ToList();
    }

    public async Task DeletePostAsyn(int id)
    {
        using var conn = _context.Connect();
        await conn.ExecuteAsync("delete from Posts where PostId=@Id", new { Id = id });
    }


    public async Task<Post> GetPostAsync(int postId)
    {
        using var connection = _context.Connect();
        return await connection.QueryFirstAsync<Post>("select * from Posts where PostId = @PostId", new { PostId = postId });
    }

    public async Task UpdatePostAsync(Post post)
    {
        using var connection = _context.Connect();
        await connection.ExecuteAsync(@"update Posts set Content=@Content, CreationDate=@CreationDate, LikesCount=@LikesCount where PostId=@PostId", post);
    }
}
