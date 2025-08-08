
namespace Domain.Models;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<IEnumerable<Post>> GetAllByUserAsync(int userId);
    Task<IEnumerable<Post>> GetAllByAlbumAsync(int albumId);
    Task<Post?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(Post post);
    Task<bool> CreateAsync(Post post);
}
