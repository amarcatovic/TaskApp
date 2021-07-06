using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TaskApp.Users.Data.Commands;
using TaskApp.Users.Services;
using TaskApp.Users.Utilities.Contants;

namespace TaskApp.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                return Ok(await _userService.GetAllUsersAsync());
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Gets single user by id
        /// </summary>
        /// <param name="id">users id</param>
        /// <returns>User object or null</returns>
        [HttpGet("{id:int}", Name = "GetUserByIdAsync")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                var response = await _userService.GetUserByIdAsync(id);
                if (response == null)
                {
                    return NotFound(ResponseConstants.ERROR_NO_SPECIFIC_USER_FOUND_ID);
                }

                return Ok(response);
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Gets single user by email
        /// </summary>
        /// <param name="email">users email</param>
        /// <returns>User object or null</returns>
        [HttpGet("{email}", Name = "GetUserByEmailAsync")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            try
            {
                var response = await _userService.GetUserByEmailAsync(email);
                if (response == null)
                {
                    return NotFound(ResponseConstants.ERROR_NO_SPECIFIC_USER_FOUND_EMAIL);
                }

                return Ok(response);
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Creates user from CreateUser Command object
        /// </summary>
        /// <param name="user">CreateUser Command object</param>
        /// <returns>status code 201 if okay, status code 400 otherwise</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync(CreateUser user)
        {
            try
            {
                var response = await _userService.AddUserAsync(user);
                if (response == null)
                {
                    return BadRequest(ResponseConstants.ERROR_CREATING_USER);
                }

                return StatusCode(201, response);
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }
    }
}
