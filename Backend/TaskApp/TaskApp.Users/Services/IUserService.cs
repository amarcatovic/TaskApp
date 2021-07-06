using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Users.Data.Commands;
using TaskApp.Users.Data.Dtos;
using TaskApp.Users.Data.Events;

namespace TaskApp.Users.Services
{
    public interface IUserService
    {
        Task<UserReadDto> AddUserAsync(CreateUser user);

        Task<UserReadDto> GetUserByIdAsync(int id);

        Task<UserReadDto> GetUserByEmailAsync(string email);

        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
    }
}
