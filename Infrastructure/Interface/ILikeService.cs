using Domain.Models;

namespace Infrastructure.Interface;

public interface ILikeService
{
    Task AddLikeAsync(Like like);
    Task<List<Like>>GetLikesOfPostAsync(int postId);
    Task DeleteLikeAsync(Like like);

}
