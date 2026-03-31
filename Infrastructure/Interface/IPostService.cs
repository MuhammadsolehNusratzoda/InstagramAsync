using Domain.Models;

namespace Infrastructure.Interface;

public interface IPostService
{
    Task AddPostAsync (Post post);
    Task<Post>GetPostAsync(int postId);
    Task<List<Post>>GetPostsAsync();
    Task UpdatePostAsync(Post post);
    Task DeletePostAsyn(int postId);
}
