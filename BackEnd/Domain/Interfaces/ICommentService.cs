using Domain.Models;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<IEnumerable<Comment>> GetByPostAsync(int postId);
        Task<IEnumerable<Comment>> GetByUserAsync(int userId);
        Task<Comment?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Comment comment);
        Task<bool> UpdateAsync(Comment comment);
        Task<bool> DeleteAsync(int id);
    }
}
