using Assignment_2.Shared.Models;

namespace Assignment_2.Shared.Services
{
    public interface IUserService
    {
        // Going to chuck the comment here to explain all steps for services related to User.
        // User has 3 files that communicate with one another, and one interface (this one) that two of them inherit from.
        // IUserService: Defines the blueprint for various CRUD operations, used in ClientUserService and UserService.
        // UserService: Server-side implementation of interface, interacting with the database context
        // ClientUserService: Client-side implementation of interface, interacting with the controller through HTTP
        // requests to perform operations.
        // UserController: Acts as a bridge between client requests and server-side services
        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetByCredentials(User user);
        Task<bool> UserWithEmailExists(string email);
    }
}
