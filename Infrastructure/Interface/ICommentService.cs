using Domain.Models;

namespace Infrastructure.Interface;

public interface ICommentService
{
    Task AddCommentAsync(Comment comment);
    Task<List<Comment>> GetCommentsOfPostsAsync(int postId);
    Task DeleteCommentAsync(int commentId);
}
