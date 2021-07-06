using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskApp.Auth.Data.ModelObjects;
using TaskApp.Auth.Utilities;
using TaskApp.Auth.Utilities.Constants;
using TaskApp.Auth.Utilities.RestClients;

namespace TaskApp.Auth.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private UserRestClient _userRestClient;

        public AuthService(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userRestClient = new UserRestClient();
        }

        /// <summary>
        /// Adds user email and password to db and creates user role
        /// </summary>
        /// <param name="email">users email</param>
        /// <param name="password">users password</param>
        /// <returns>True is success, false otherwise</returns>
        public async Task<bool> RegisterUserAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var userByEmail = await _userManager.FindByEmailAsync(email);

            if (userByEmail != null)
            {
                return false;
            }

            var user = new IdentityUser()
            {
                Email = email,
                UserName = email
            };


            var createUser = await _userManager.CreateAsync(user, password);
            if (createUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleConstants.USER_ROLE);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthResultObject> AuthenticateUserAsync(string email, string password)
        {
            var userFromDb = await _userManager.FindByEmailAsync(email);
            if (userFromDb == null || !await _userManager.CheckPasswordAsync(userFromDb, password))
            {
                return null;
            }

            var user = await _userRestClient.GetUserByEmailAsync(email);

            var role = await _userManager.GetRolesAsync(userFromDb);
            var _options = new IdentityOptions();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim("userId", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }
                ),
                Expires = DateTime.Now.AddYears(100), // Never Expires
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value.ToString())),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new AuthResultObject()
            {
                Token = token,
                User = user
            };
        }
    }
}
