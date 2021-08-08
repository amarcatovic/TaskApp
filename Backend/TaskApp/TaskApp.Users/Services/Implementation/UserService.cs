using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RabbitMQ.Messaging.Infrastructure;
using TaskApp.Users.Data;
using TaskApp.Users.Data.Commands;
using TaskApp.Users.Data.Dtos;
using TaskApp.Users.Data.Events;
using TaskApp.Users.Data.Models;
using TaskApp.Users.Utilities.RestClients;

namespace TaskApp.Users.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UsersContext _context;
        private readonly IMessagePublisher _messagePublisher;
        private readonly IMapper _mapper;
        private PhotosRestClient _photosRestClient;

        public UserService(UsersContext context,
            IMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _context = context;
            _messagePublisher = messagePublisher;
            _mapper = mapper;
            _photosRestClient = new PhotosRestClient();
        }

        /// <summary>
        /// Adds user and sends message to auth and photo service
        /// </summary>
        /// <param name="user">CreateUser Command Object</param>
        /// <returns>True if user was added successfully, false otherwise</returns>
        public async Task<UserReadDto> AddUserAsync(CreateUser user)
        {
            await using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var newUser = _mapper.Map<User>(user);
                var userAdded = await _context.Users.AddAsync(newUser);
                newUser = userAdded.Entity;

                var userCreatedEvent = _mapper.Map<UserCreated>(user);
                userCreatedEvent.Id = newUser.Id;
                await _messagePublisher.PublishMessageAsync(userCreatedEvent.MessageType, userCreatedEvent,
                    string.Empty);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return _mapper.Map<UserReadDto>(userCreatedEvent);
            }
            catch
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        /// <summary>
        /// Finds user which email matches given email
        /// </summary>
        /// <param name="id">users id</param>
        /// <returns>User object or null</returns>
        public async Task<UserReadDto> GetUserByIdAsync(int id)
        {
            var userFromDb = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = _mapper.Map<UserReadDto>(userFromDb);
            CreateUserInitials(ref result);
            var photo = await _photosRestClient.GetPhotoByUserId(result.Id);
            if (photo != null)
            {
                result.PhotoUrl = photo.PhotoUrl;
            }

            return result;
        }

        /// <summary>
        /// Finds user which id matches given id
        /// </summary>
        /// <param name="email">users email</param>
        /// <returns>User object or null</returns>
        public async Task<UserReadDto> GetUserByEmailAsync(string email)
        {
            var userFromDb = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);

            var result = _mapper.Map<UserReadDto>(userFromDb);
            CreateUserInitials(ref result);
            var photo = await _photosRestClient.GetPhotoByUserId(result.Id);
            if (photo != null)
            {
                result.PhotoUrl = photo.PhotoUrl;
            }

            return result;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of User objects</returns>
        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            var usersFromDb = await _context.Users
                .AsNoTracking()
                .ToListAsync();
            var result = new List<UserReadDto>();

            foreach (var user in usersFromDb)
            {
                var mappedUser = _mapper.Map<UserReadDto>(user);
                CreateUserInitials(ref mappedUser);
                var photo = await _photosRestClient.GetPhotoByUserId(mappedUser.Id);
                if (photo != null)
                {
                    mappedUser.PhotoUrl = photo.PhotoUrl;
                }

                result.Add(mappedUser);
            }

            return result;
        }

        private void CreateUserInitials(ref UserReadDto user)
        {
            if (user.FirstName != null && user.LastName != null)
            {
                user.Initials = user.FirstName.Substring(0, 1) + user.LastName.Substring(0, 1);
            }

            else if (user.FirstName != null && user.LastName == null)
            {
                user.Initials = user.FirstName.Substring(0, 1);
            }

            else if (user.FirstName == null && user.LastName != null)
            {
                user.Initials = user.LastName.Substring(0, 1);
            }
        }
    }
}
