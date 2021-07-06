using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TaskApp.Photos.Data.Models;

namespace TaskApp.Photos.Repositories
{
    public interface IPhotoRepository
    {
        Task<bool> AddPhotoAsync(int userId, string photoUrl);

        Task<Photo> GetPhotoByUserId(int userId);
    }
}
