using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using RabbitMQ.Messaging.Infrastructure;
using TaskApp.Users.Utilities.Annotations;

namespace TaskApp.Users.Data.Commands
{
    public class CreateUser : Command
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(2)]
        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }
    }
}
