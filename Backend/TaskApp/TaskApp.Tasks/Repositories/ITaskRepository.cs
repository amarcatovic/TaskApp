using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Tasks.Data.Commands;
using Task = TaskApp.Tasks.Data.Models.Task;

namespace TaskApp.Tasks.Repositories
{
    public interface ITaskRepository
    {
        Task<bool> CreateTaskAsync(Task task);

        Task<bool> EditTaskAsync(int taskId, Task task);

        Task<List<Task>> GetMostRecentTasksAsync();

        Task<List<Task>> GetAllUserTasksAsync(int userId);

        Task<List<Task>> GetAllUserAssignedTasksAsync(int userId);

        Task<List<Task>> GetAllExpiringTasksAsync();
    }
}
