using Domain.Models;

namespace Application.Services
{
    public class PostService
    {
        private readonly IPostRepo _postRepo;
        public PostService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<IEnumerable<Post>> GetAllAsync() {return await _postRepo.GetAllAsync(); }
        
        public async Task<Post> GetByIdAsync(int id) { return await _postRepo.GetByIdAsync(id);} 

        public async Task<bool> DeleteAsync(int id) { return await _postRepo.DeleteAsync(id);}

        public async Task<bool> UpdateAsync(Post post) { return await _postRepo.UpdateAsync(post);}

        public async Task<bool> CreateAsync(Post post) { return await _postRepo.CreateAync(post);}
    }
}
