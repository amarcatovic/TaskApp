using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Messaging.Infrastructure;
using TaskApp.Notifications.Data.UserService;

namespace TaskApp.Notifications.Data.TaskService
{
    public class TaskCreated : Event
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public UserReadDto User { get; set; }

        public UserReadDto Assignee { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
    }
}
