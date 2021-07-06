using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Auth.Data.ModelObjects;

namespace TaskApp.Auth.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(string email, string password);
        Task<AuthResultObject> AuthenticateUserAsync(string email, string password);
    }
}
