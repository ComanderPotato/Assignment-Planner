using Assignment_2.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Shared.Services
{
    // Read ITaskItemService
    public class ClientTaskItemService : ITaskItemService
    {
        private readonly HttpClient _httpClient;

        public ClientTaskItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TaskItem> AddTaskItem(TaskItem taskItem)
        {
            var results = await _httpClient.PostAsJsonAsync("/api/taskitem", taskItem);
            return await results.Content.ReadFromJsonAsync<TaskItem>();
        }

        public async Task<bool> DeleteTaskItem(TaskItem taskItem)
        {
            var results = await _httpClient.DeleteAsync($"/api/taskitem/{taskItem}");
            return await results.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<List<TaskItem>> GetAllTaskItems()
        {
            var results = await _httpClient.GetFromJsonAsync<List<TaskItem>>("/api/taskitem");
            return results;
        }

        public async Task<TaskItem> GetById(int id)
        {
            var results = await _httpClient.GetFromJsonAsync<TaskItem>($"/api/taskitem{id}");
            return results;
        }

        public async Task<List<TaskItem>> GetTaskItemsByUserId(int userId)
        {
            var results = await _httpClient.GetFromJsonAsync<List<TaskItem>>($"/api/taskitem/user/{userId}");
            return results;
        }

        public async Task<bool> UpdateTaskItem(TaskItem taskItem)
        {
            var results = await _httpClient.PostAsJsonAsync($"/api/taskitem", taskItem);
            return await results.Content.ReadFromJsonAsync<bool>();
        }
    }
}
