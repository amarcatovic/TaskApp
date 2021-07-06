using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Notifications.Services
{
    public interface IEmailService
    {
        Task<bool> SendTaskCreatedEmailAsync(string to, string subject, string body, DateTime finishDate, bool isHTML = true);
    }
}
