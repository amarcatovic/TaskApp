using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Auth.Data.Commands;
using TaskApp.Auth.Services;
using TaskApp.Auth.Utilities.Constants;

namespace TaskApp.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AuthenticateUserAsync([FromBody] AuthenticateUser user)
        {
            try
            {
                var result = await _authService.AuthenticateUserAsync(user.Email, user.Password);
                if (result == null)
                {
                    return BadRequest(ResponseConstants.AUTH_USER_EMAIL_OR_PASSWORD_WRONG);
                }

                return Ok(result);
            }
            catch
            {
                return BadRequest(ResponseConstants.AUTH_USER_SOMETHING_WENT_WRONG);
            }
        }
    }
}
