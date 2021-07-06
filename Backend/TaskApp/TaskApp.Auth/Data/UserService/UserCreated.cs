using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using RabbitMQ.Messaging.Infrastructure;

namespace TaskApp.Auth.Data.UserService
{
    public class UserCreated : Event
    {
        /// <summary>
        /// Users Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Users email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Users Raw Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
