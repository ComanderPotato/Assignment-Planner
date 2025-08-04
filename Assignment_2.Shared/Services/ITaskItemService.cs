using Assignment_2.Shared.Models;

namespace Assignment_2.Shared.Services
{
    public interface ITaskItemService
    {
        // Going to chuck the comment here to explain all steps for services related to TaskItem.
        // TaskItem has 3 files that communicate with one another, and one interface (this one) that two of them inherit from.
        // ITaskItemService: Defines the blueprint for various CRUD operations, used in ClientTaskItemService and TaskItemService.
        // TaskItemService: Server-side implementation of interface, interacting with the database context
        // ClientTaskItemService: Client-side implementation of interface, interacting with the controller through HTTP
        // requests to perform operations.
        //TaskItemController: Acts as a bridge between client requests and server-side services
        Task<List<TaskItem>> GetAllTaskItems();
        Task<TaskItem> AddTaskItem(TaskItem taskItem);
        Task<bool> UpdateTaskItem(TaskItem taskItem);
        Task<bool> DeleteTaskItem(TaskItem taskItem);
        Task<List<TaskItem>> GetTaskItemsByUserId(int userId);
        Task<TaskItem> GetById(int id);
    }
}
