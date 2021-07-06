using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TaskApp.Photos.Data.Dtos;

namespace TaskApp.Photos.Services
{
    public interface IPhotoService
    {
        Task<bool> AddPhotoAsync(int userId, IFormFile photo);

        Task<PhotoReturnDto> GetPhotoByUserId(int userId);
    }
}
