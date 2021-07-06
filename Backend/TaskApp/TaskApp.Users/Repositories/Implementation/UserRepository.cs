using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskApp.Users.Data;
using TaskApp.Users.Data.Models;

namespace TaskApp.Users.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _context;

        public UserRepository(UsersContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds user to the database
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>True if user was added, false otherwise</returns>
        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Finds user with specific id
        /// </summary>
        /// <param name="id">users id</param>
        /// <returns>User object if found, null otherwise</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Finds user with specific email
        /// </summary>
        /// <param name="email">users email</param>
        /// <returns>User object if found, null otherwise</returns>
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// Extracts all users from database
        /// </summary>
        /// <returns>List of user objects</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .ToListAsync();
        }

        /// <summary>
        /// Saves changes in the database
        /// </summary>
        /// <returns>True if changes are successful, false otherwise</returns>
        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
