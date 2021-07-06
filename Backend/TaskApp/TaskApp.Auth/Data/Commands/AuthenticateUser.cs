using System.ComponentModel.DataAnnotations;

namespace TaskApp.Auth.Data.Commands
{
    public class AuthenticateUser
    {
        /// <summary>
        /// User's email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Raw password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
