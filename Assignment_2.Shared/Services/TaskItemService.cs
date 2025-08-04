using Assignment_2.Shared.Data;
using Assignment_2.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Shared.Services
{
    // Read ITaskItemService
    public class TaskItemService : ITaskItemService
    {
        private readonly ApplicationDbContext _context;

        public TaskItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> AddTaskItem(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<List<TaskItem>> GetTaskItemsByUserId(int userId)
        {
            return await _context.TaskItems
                .Where(taskItem => taskItem.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> DeleteTaskItem(TaskItem taskItem)
        {
            var existingTaskItem = await _context.TaskItems.FindAsync(taskItem.Id);
            if (existingTaskItem != null)
            {
                _context.TaskItems.Remove(existingTaskItem);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<TaskItem>> GetAllTaskItems()
        {
            var taskItems = await _context.TaskItems.ToListAsync();
            return taskItems;
        }

        public async Task<TaskItem> GetById(int id)
        {
            var taskItem = await _context.TaskItems.FirstOrDefaultAsync(taskItem => taskItem.Id == id);
            return taskItem;
        }

        public async Task<bool> UpdateTaskItem(TaskItem taskItem)
        {
            var existingTaskItem = await _context.TaskItems.FindAsync(taskItem.Id);
            if (existingTaskItem != null)
            {
                existingTaskItem.SubjectID = taskItem.SubjectID;
                existingTaskItem.SubjectName = taskItem.SubjectName;
                existingTaskItem.TaskItemTitle = taskItem.TaskItemTitle;
                existingTaskItem.Date = taskItem.Date;
                existingTaskItem.Description = taskItem.Description;

                if (existingTaskItem is Assignment existingAssignment && taskItem is Assignment updatedAssignment)
                {
                    existingAssignment.Percentage = updatedAssignment.Percentage;
                    existingAssignment.AchievedMark = updatedAssignment.AchievedMark;
                    existingAssignment.TotalMark = updatedAssignment.TotalMark;
                }

                _context.TaskItems.Update(existingTaskItem);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
