using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Photos.Data.Dtos;
using TaskApp.Photos.Services;

namespace TaskApp.Photos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPhotoByUserId(int userId)
        {
            try
            {
                var result = await _photoService.GetPhotoByUserId(userId);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserPhoto([FromForm] PhotoCreateDto photoCreateDto)
        {
            try
            {
                var response = await _photoService.AddPhotoAsync(photoCreateDto.UserId, photoCreateDto.PhotoFile);
                if (!response)
                {
                    return BadRequest();
                }

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
