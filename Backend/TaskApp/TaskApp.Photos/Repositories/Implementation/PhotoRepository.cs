using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using TaskApp.Photos.Data.Models;
using TaskApp.Photos.Utilities.Database;

namespace TaskApp.Photos.Repositories.Implementation
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IMongoCollection<Photo> _photos;

        public PhotoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _photos = database.GetCollection<Photo>(settings.PhotosCollectionName);
        }

        /// <summary>
        /// Adds photo to MongoDB
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="photoUrl">photo url on cloudinary</param>
        /// <returns>true if success, false otherwise</returns>
        public async Task<bool> AddPhotoAsync(int userId, string photoUrl)
        {
            var newPhoto = new Photo()
            {
                Id = new Guid(),
                UserId = userId,
                PhotoUrl = photoUrl
            };

            try
            {
                await _photos.InsertOneAsync(newPhoto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets users profile photo
        /// </summary>
        /// <param name="userId">users id</param>
        /// <returns>Users photo</returns>
        public async Task<Photo> GetPhotoByUserId(int userId)
        {
            return await _photos
                .Find(p => p.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
