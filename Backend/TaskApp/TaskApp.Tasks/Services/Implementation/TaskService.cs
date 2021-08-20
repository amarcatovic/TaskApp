using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RabbitMQ.Messaging.Infrastructure;
using TaskApp.Tasks.Data;
using TaskApp.Tasks.Data.Commands;
using TaskApp.Tasks.Data.Dtos;
using TaskApp.Tasks.Data.Events;
using TaskApp.Tasks.Utilities.RestClients;
using Task = TaskApp.Tasks.Data.Models.Task;

namespace TaskApp.Tasks.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly TaskContext _context;
        private readonly IMessagePublisher _messagePublisher;
        private readonly IMapper _mapper;
        private UsersRestClient _usersRestClient;

        public TaskService(TaskContext context,
            IMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _context = context;
            _messagePublisher = messagePublisher;
            _mapper = mapper;
            _usersRestClient = new UsersRestClient();
        }
        public async Task<bool> CreateTaskAsync(CreateTask createTask)
        {
            var task = _mapper.Map<Data.Models.Task>(createTask);
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();

                var taskCreatedEvent = new TaskCreated()
                {
                    Title = createTask.Title,
                    Description = createTask.Description,
                    User = await _usersRestClient.GetUserById(task.UserId),
                    Assignee = await _usersRestClient.GetUserById(task.AssigneeId),
                    StartDate = createTask.StartDate,
                    FinishDate = createTask.FinishDate
                };

                await _messagePublisher.PublishMessageAsync(taskCreatedEvent.MessageType, taskCreatedEvent,
                    string.Empty);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> EditTaskAsync(int taskId, EditTask editTask)
        {
            var task = _mapper.Map<Task>(editTask);
            return await _taskRepository.EditTaskAsync(taskId, task);
        }

        public async Task<IEnumerable<TaskReadDto>> GetMostRecentTasksAsync()
        {
            var tasks = await _taskRepository.GetMostRecentTasksAsync();
            var result = new List<TaskReadDto>();

            foreach (var task in tasks)
            {
                var mappedTask = _mapper.Map<TaskReadDto>(task);
                mappedTask.User = await _usersRestClient.GetUserById(task.UserId);
                mappedTask.Assignee = await _usersRestClient.GetUserById(task.AssigneeId);
                result.Add(mappedTask);
            }

            return result;
        }

        public async Task<IEnumerable<TaskReadDto>> GetAllUserTasksAsync(int userId)
        {
            var tasks = await _taskRepository.GetAllUserTasksAsync(userId);
            var result = new List<TaskReadDto>();

            foreach (var task in tasks)
            {
                var mappedTask = _mapper.Map<TaskReadDto>(task);
                mappedTask.User = await _usersRestClient.GetUserById(task.UserId);
                mappedTask.Assignee = await _usersRestClient.GetUserById(task.AssigneeId);
                result.Add(mappedTask);
            }

            return result;
        }

        public async Task<IEnumerable<TaskReadDto>> GetAllUserAssignedTasksAsync(int userId)
        {
            var tasks = await _taskRepository.GetAllUserAssignedTasksAsync(userId);
            var result = new List<TaskReadDto>();

            foreach (var task in tasks)
            {
                var mappedTask = _mapper.Map<TaskReadDto>(task);
                mappedTask.User = await _usersRestClient.GetUserById(task.UserId);
                mappedTask.Assignee = await _usersRestClient.GetUserById(task.AssigneeId);
                result.Add(mappedTask);
            }

            return result;
        }

        public async Task<IEnumerable<TaskReadDto>> GetAllExpiringTasksAsync()
        {
            var tasks = await _taskRepository.GetAllExpiringTasksAsync();
            var result = new List<TaskReadDto>();

            foreach (var task in tasks)
            {
                var mappedTask = _mapper.Map<TaskReadDto>(task);
                mappedTask.User = await _usersRestClient.GetUserById(task.UserId);
                mappedTask.Assignee = await _usersRestClient.GetUserById(task.AssigneeId);
                result.Add(mappedTask);
            }

            return result;
        }
    }
}
