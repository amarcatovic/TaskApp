using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Notifications.Data.TaskService;

namespace TaskApp.Notifications.Services.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;

        public NotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendEmailToTaskAssigneeAsync(TaskCreated taskCreated)
        {
            await _emailService.SendTaskCreatedEmailAsync(taskCreated.Assignee.Email, "New Task on TaskApp", taskCreated.Title, taskCreated.FinishDate);
        }
    }
}
