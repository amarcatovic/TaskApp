using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using TaskApp.Tasks.Data.Commands;
using TaskApp.Tasks.Services;
using TaskApp.Tasks.Utilities.Attributes;
using TaskApp.Tasks.Utilities.Constants;

namespace TaskApp.Tasks.Controllers
{
    [AuthorizeJwt]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Creates a new task and stores it in the database
        /// </summary>
        /// <param name="createTask">CreateTask Command object</param>
        /// <returns>Status code 201 or 400</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(CreateTask createTask)
        {
            try
            {
                var response = await _taskService.CreateTaskAsync(createTask);
                if (!response)
                {
                    return BadRequest(ResponseConstants.ERROR_CREATING_TASK);
                }

                return StatusCode(201);
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Edits existing task
        /// </summary>
        /// <param name="createTask">CreateTask Command object</param>
        /// <returns>Status code 204 or 404</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTaskAsync(int id, EditTask editTask)
        {
            try
            {
                var response = await _taskService.EditTaskAsync(id, editTask);
                if (!response)
                {
                    return BadRequest(ResponseConstants.ERROR_EDITING_TASK);
                }

                return NoContent();
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Finds top 10 recently created tasks
        /// </summary>
        /// <returns>List of tasks</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetMostRecentTasksAsync()
        {
            try
            {
                return Ok(await _taskService.GetMostRecentTasksAsync());
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Finds top 10 recently created tasks and returns JSON file as download for them
        /// </summary>
        /// <returns>JSON file with a List of tasks</returns>
        [HttpGet("download")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadMostRecentTasksAsync()
        {
            try
            {
                var download = Encoding.UTF8.GetBytes(
                    JsonConvert.SerializeObject(
                        await _taskService.GetMostRecentTasksAsync(), 
                        new JsonSerializerSettings())
                    );

                return File(download , "application/json", "tasks.json");
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Finds all tasks that user created
        /// </summary>
        /// <param name="userId">id of a user that created tasks</param>
        /// <returns>List of tasks</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllUserTasksAsync(int userId)
        {
            try
            {
                var response = await _taskService.GetAllUserTasksAsync(userId);
                if (!response.Any())
                {
                    return NotFound(ResponseConstants.NOT_FOUND_USER_TASKS);
                }

                return Ok(response);
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Finds all tasks that are assigned to a user
        /// </summary>
        /// <param name="userId">id of a user that is assigned to tasks</param>
        /// <returns>List of tasks</returns>
        [HttpGet("assigned/{userId}")]
        public async Task<IActionResult> GetAllUserAssignedTasksAsync(int userId)
        {
            try
            {
                var response = await _taskService.GetAllUserAssignedTasksAsync(userId);
                if (!response.Any())
                {
                    return NotFound(ResponseConstants.NOT_FOUND_USER_ASSIGNED_TASKS);
                }

                return Ok(response);
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }

        /// <summary>
        /// Finds all expiring tasks
        /// </summary>
        /// <returns>List of expiring tasks</returns>
        [HttpGet("expiring")]
        public async Task<IActionResult> GetAllExpiringTasksAsync()
        {
            try
            {
                return Ok(await _taskService.GetAllExpiringTasksAsync());
            }
            catch
            {
                return BadRequest(ResponseConstants.ERROR_GENERIC);
            }
        }
    }
}
