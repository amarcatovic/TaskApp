using System.Threading.Tasks;
using TaskApp.Notifications.Data.TaskService;

namespace TaskApp.Notifications.Services
{
    public interface INotificationService
    {
        Task SendEmailToTaskAssigneeAsync(TaskCreated taskCreated);
    }
}
