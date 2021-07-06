using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TaskApp.Photos.Data.Dtos;
using TaskApp.Photos.Data.Models;
using TaskApp.Photos.Repositories;
using TaskApp.Photos.Utilities.Cloudinary;

namespace TaskApp.Photos.Services.Implementation
{
    public class PhotoService : IPhotoService
    {
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinarySettings;
        private readonly IPhotoRepository _photoRepository;
        private Cloudinary _cloudinary;

        public PhotoService(IMapper mapper,
            IOptions<CloudinarySettings> cloudinarySettings,
            IPhotoRepository photoRepository)
        {
            _mapper = mapper;
            _cloudinarySettings = cloudinarySettings;
            _photoRepository = photoRepository;

            Account account = new Account(
                _cloudinarySettings.Value.CloudName,
                _cloudinarySettings.Value.APIKey,
                _cloudinarySettings.Value.APISecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<bool> AddPhotoAsync(int userId, IFormFile photo)
        {
            var uploadResult = new ImageUploadResult();
            if (photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName, stream)
                };

                uploadResult = _cloudinary.Upload(uploadParams);
            }

            var isPhotoAdded = await _photoRepository.AddPhotoAsync(userId, uploadResult.Url.AbsoluteUri);
            if (!isPhotoAdded)
            {
                return false;
            }

            return true;
        }

        public async Task<PhotoReturnDto> GetPhotoByUserId(int userId)
        {
           var photo = await _photoRepository.GetPhotoByUserId(userId);
           return _mapper.Map<PhotoReturnDto>(photo);
        }
    }
}
