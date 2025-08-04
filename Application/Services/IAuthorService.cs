using Domain.Models;
using Application.Interfaces;


namespace Application.Services
{
    public class IAuthorService
    {
        private readonly IAuthorRepo _repository;
        public IAuthorService(IAuthorRepo repository) {  _repository = repository; }
        
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        } 

        public async Task<bool> CreateAsync(Author author)
        {
            return await _repository.CreateAsync(author);
        }

        public async Task<bool> UpdateAsync(Author author)
        {
            return await _repository.UpdateAsync(author);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
