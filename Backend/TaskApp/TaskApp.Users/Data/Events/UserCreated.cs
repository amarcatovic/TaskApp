using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RabbitMQ.Messaging.Infrastructure;

namespace TaskApp.Users.Data.Events
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
