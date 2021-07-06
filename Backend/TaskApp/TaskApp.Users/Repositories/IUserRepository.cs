using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Users.Data.Models;

namespace TaskApp.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByEmailAsync(string email);

        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
