using Assignment_2.Shared.Data;
using Assignment_2.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Shared.Services
{
    // Read IUserService
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> UpdateUser(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.Surname = user.Surname;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteUser(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            return user;
        }
        public async Task<User> GetByCredentials(User user)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(foundUser => foundUser.Email == user.Email && foundUser.Password == user.Password);
            return foundUser;
        }

        public async Task<bool> UserWithEmailExists(string email)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            return existingUser != null;
        }
    }
}
