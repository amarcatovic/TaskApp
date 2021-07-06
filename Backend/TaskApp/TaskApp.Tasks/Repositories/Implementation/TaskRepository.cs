using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApp.Tasks.Data;
using TaskApp.Tasks.Data.Commands;
using Task = TaskApp.Tasks.Data.Models.Task;

namespace TaskApp.Tasks.Repositories.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateTaskAsync(Task task)
        {
            await _context.Tasks.AddAsync(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditTaskAsync(int taskId, Task task)
        {
            var taskFromDb = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
            if (taskFromDb == null)
            {
                return false;
            }

            taskFromDb.Title = task.Title;
            taskFromDb.Description = task.Description;
            taskFromDb.StartDate = task.StartDate;
            taskFromDb.FinishDate = task.FinishDate;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Task>> GetMostRecentTasksAsync()
        {
            return await _context.Tasks
                .OrderByDescending(t => t.StartDate)
                .Take(10)
                .ToListAsync();
        }

        public async Task<List<Task>> GetAllUserTasksAsync(int userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Task>> GetAllUserAssignedTasksAsync(int userId)
        {
            return await _context.Tasks
                .Where(t => t.AssigneeId == userId)
                .ToListAsync();
        }

        public async Task<List<Task>> GetAllExpiringTasksAsync()
        {
            return await _context.Tasks
                .Where(t => !t.IsDone)
                .Where(t => t.FinishDate.AddDays(1) > DateTime.Now)
                .ToListAsync();
        }
    }
}
