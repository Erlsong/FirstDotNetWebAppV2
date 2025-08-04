
namespace Domain.Models;

public interface IPostRepo
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(Post post);
    Task<bool> CreateAync(Post post);
}
