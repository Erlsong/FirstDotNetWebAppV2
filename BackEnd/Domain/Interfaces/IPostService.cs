
namespace Domain.Models;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Post>> GetByAlbumIdAsync(int albumId);
    Task<Post?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(Post post);
    Task<bool> CreateAsync(Post post);
}
