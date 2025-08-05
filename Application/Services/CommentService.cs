using Domain.Models;
using Application.Interfaces;

namespace Application.Services
{
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository _repo;
        public CommentService(ICommentRepository repo) {  _repo = repo; }
        
        public async Task<IEnumerable<Comment>> GetAllAsync() { return await _repo.GetAllAsync(); }

        public async Task<Comment?> GetByIdAsync(int id) { return await _repo.GetByIdAsync(id); }

        public async Task<bool> CreateAsync(Comment comment) { return await _repo.CreateAsync(comment); }

        public async Task<bool> UpdateAsync(Comment comment) { return await _repo.UpdateAsync(comment); }

        public async Task<bool> DeleteAsync(int id) { return await _repo.DeleteAsync(id); }
    }
}
