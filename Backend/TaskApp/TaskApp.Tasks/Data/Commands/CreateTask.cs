using System;
using System.ComponentModel.DataAnnotations;
using RabbitMQ.Messaging.Infrastructure;

namespace TaskApp.Tasks.Data.Commands
{
    public class CreateTask : Command
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int AssigneeId { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        public DateTime FinishDate { get; set; }
    }
}
