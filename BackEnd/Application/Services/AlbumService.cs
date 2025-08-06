using Domain.Models;
using Application.Interfaces;

namespace Application.Services
{
    public class AlbumService: IAlbumService
    {
        private readonly IAlbumRepository _repository;
        public AlbumService(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Album>> GetAllByAuthorAsync(int authorId) {  return await _repository.GetAllByAuthorAsync(authorId); }

        public async Task<Album?> GetByIdAsync(int id) { return  await _repository.GetByIdAsync(id);}

        public async Task<bool> DeleteAsync(int id) { return await _repository.DeleteAsync(id); }

        public async Task<bool> CreateAsync(Album album) {  return await _repository.CreateAsync(album);}

        public async Task<bool> UpdateAsync(Album album) { return await _repository.UpdateAsync(album);}
    }
}
