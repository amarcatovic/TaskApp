using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Tasks.Data.Commands;
using TaskApp.Tasks.Data.Dtos;

namespace TaskApp.Tasks.Services
{
    public interface ITaskService
    {
        Task<bool> CreateTaskAsync(CreateTask task);

        Task<bool> EditTaskAsync(int taskId, EditTask task);

        Task<IEnumerable<TaskReadDto>> GetMostRecentTasksAsync();

        Task<IEnumerable<TaskReadDto>> GetAllUserTasksAsync(int userId);

        Task<IEnumerable<TaskReadDto>> GetAllUserAssignedTasksAsync(int userId);

        Task<IEnumerable<TaskReadDto>> GetAllExpiringTasksAsync();
    }
}
