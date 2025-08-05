using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAllByAuthorAsync(int authorId);
        Task<Album?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> CreateAsync(Album album);
        Task<bool> UpdateAsync(Album album);
    }
}
