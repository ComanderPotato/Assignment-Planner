using Assignment_2.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Shared.Services
{
    // Read IUserService
    public class ClientUserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public ClientUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> AddUser(User user)
        {
            var results = await _httpClient.PostAsJsonAsync("/api/user", user);
            return await results.Content.ReadFromJsonAsync<User>();
        }

        public async Task<bool> DeleteUser(User user)
        {
            var results = await _httpClient.DeleteAsync($"/api/user/{user}");
            return await results.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var results = await _httpClient.GetFromJsonAsync<List<User>>("/api/user");
            return results;

        }

        public async Task<User> GetByCredentials(User user)
        {
            var results = await _httpClient.PostAsJsonAsync("/api/user/login", user);
            return await results.Content.ReadFromJsonAsync<User>();
        }

        public async Task<User> GetUserById(int id)
        {
            var results = await _httpClient.GetFromJsonAsync<User>($"/api/user{id}");
            return results;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var results = await _httpClient.PostAsJsonAsync($"/api/user", user);
            return await results.Content.ReadFromJsonAsync<bool>();

        }

        public async Task<bool> UserWithEmailExists(string email)
        {
            var results = await _httpClient.GetFromJsonAsync<bool>($"/api/user/exist?email={Uri.EscapeDataString(email)}");
            return results;
        }
    }
}
