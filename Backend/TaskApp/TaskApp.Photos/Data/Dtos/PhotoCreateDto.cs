using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TaskApp.Photos.Data.Dtos
{
    public class PhotoCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public IFormFile PhotoFile { get; set; }
    }
}
