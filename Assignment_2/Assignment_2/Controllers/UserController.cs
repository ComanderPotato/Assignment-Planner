using Assignment_2.Shared.Models;
using Assignment_2.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                var addedUser = await _userService.AddUser(user);
                return Ok(addedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the user: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the user.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} was not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the user: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving the user.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all users: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving all users.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest("User ID does not match.");
                }
                await _userService.UpdateUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the user: {ex.Message}");
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} was not found.");
                }
                await _userService.DeleteUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }

        [HttpGet("exist")]
        public async Task<ActionResult<bool>> UserWithEmailExists(string email)
        {
            try
            {
                bool exists = await _userService.UserWithEmailExists(email);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking if user with email exists: {ex.Message}");
                return StatusCode(500, "An error occurred while checking if the email exists.");
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> GetByCredentials(User user)
        {
            try
            {
                var authenticatedUser = await _userService.GetByCredentials(user);
                if (authenticatedUser == null)
                {
                    return Unauthorized("Invalid credentials.");
                }
                return Ok(authenticatedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during user authentication: {ex.Message}");
                return StatusCode(500, "An error occurred during authentication.");
            }
        }
    }
}
