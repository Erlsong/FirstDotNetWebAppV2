using Domain.Models;

namespace Application.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAllAsync();
        Task<IEnumerable<Album>> GetAllByAuthorAsync(int authorId);
        Task<Album?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> CreateAsync(Album album);
        Task<bool> UpdateAsync(Album album);

    }
}
