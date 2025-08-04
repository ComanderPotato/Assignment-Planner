using Assignment_2.Shared.Models;
using Assignment_2.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> AddTaskItem(TaskItem taskItem)
        {
            try
            {
                var addedTaskItem = await _taskItemService.AddTaskItem(taskItem);
                return Ok(addedTaskItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the task: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the task.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItemById(int id)
        {
            try
            {
                var taskItem = await _taskItemService.GetById(id);
                if (taskItem == null)
                {
                    return NotFound();
                }
                return Ok(taskItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the task item: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving the task item.");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTaskItemsByUserId(int userId)
        {
            try
            {
                var taskItems = await _taskItemService.GetTaskItemsByUserId(userId);
                if (taskItems == null || !taskItems.Any())
                {
                    return NotFound($"No task items found for user ID {userId}.");
                }
                return Ok(taskItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving tasks for user: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving tasks for the user.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAllTaskItems()
        {
            try
            {
                var taskItems = await _taskItemService.GetAllTaskItems();
                return Ok(taskItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all tasks: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving all tasks.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskItem(int id, TaskItem taskItem)
        {
            try
            {
                if (id != taskItem.Id)
                {
                    return BadRequest("Task ID does not match.");
                }
                await _taskItemService.UpdateTaskItem(taskItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the task: {ex.Message}");
                return StatusCode(500, "An error occurred while updating the task.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            try
            {
                var taskItem = await _taskItemService.GetById(id);
                if (taskItem == null)
                {
                    return NotFound();
                }
                await _taskItemService.DeleteTaskItem(taskItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the task item: {ex.Message}");
                return StatusCode(500, "An error occurred while deleting the task item.");
            }
        }
    }
}
