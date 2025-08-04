using Assignment_2.Shared.Data;
using Assignment_2.Shared.Models;
using Assignment_2.Shared.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Assignment_2.Tests
{
    public class UserTests
    {
        private ApplicationDbContext _dbContext;
        private UserService _userService;
        private User dummyUser = new User { Id = 1, FirstName = "Dummy", Surname = "Test", Email = "Dummy@outlook.com", Password = "Password1" };

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            _userService = new UserService(_dbContext);
            _dbContext.Users.RemoveRange(_dbContext.Users);
            SeedDatabase(_dbContext); 
        }

        private void SeedDatabase(ApplicationDbContext context)
        {
            context.Users.Add(dummyUser);
            context.SaveChanges();
        }

        [Test]
        public async Task AddUserTest()
        {
            var newUser = new User { FirstName = "New", Surname = "User", Email = "new@outlook.com", Password = "NewPassword1" };

            var addedUser = await _userService.AddUser(newUser);

            Assert.IsNotNull(addedUser);
            Assert.That(addedUser.Id, Is.EqualTo(2));
            Assert.That(addedUser.FirstName, Is.EqualTo(newUser.FirstName));
            Assert.That(addedUser.Surname, Is.EqualTo(newUser.Surname));
            Assert.That(addedUser.Email, Is.EqualTo(newUser.Email));
            Assert.That(addedUser.Password, Is.EqualTo(newUser.Password));
        }

        [Test]
        public async Task GetUserTest()
        {
            var retrievedUser = await _userService.GetUserById(dummyUser.Id);

            Assert.IsNotNull(retrievedUser);
            Assert.That(retrievedUser.FirstName, Is.EqualTo("Dummy"));
            Assert.That(retrievedUser.Surname, Is.EqualTo("Test"));
            Assert.That(retrievedUser.Email, Is.EqualTo("Dummy@outlook.com"));
        }

        [Test]
        public async Task UpdateUserTest()
        {
            string newFirstName = "UpdatedFirstName";
            string newSurname = "UpdatedSurname";

            bool isUpdated = await _userService.UpdateUser(new User
            {
                Id = dummyUser.Id,
                FirstName = newFirstName,
                Surname = newSurname,
                Email = dummyUser.Email,
                Password = dummyUser.Password
            });

            Assert.IsTrue(isUpdated);
            var updatedUser = await _userService.GetUserById(dummyUser.Id);
            Assert.That(updatedUser.FirstName, Is.EqualTo(newFirstName));
            Assert.That(updatedUser.Surname, Is.EqualTo(newSurname));
        }

        [Test]
        public async Task DeleteUserTest()
        {
            var retrievedUser = await _userService.GetUserById(dummyUser.Id);
            Assert.IsNotNull(retrievedUser);

            bool isDeleted = await _userService.DeleteUser(retrievedUser);

            Assert.IsTrue(isDeleted);
            var deletedUser = await _userService.GetUserById(dummyUser.Id);
            Assert.That(deletedUser, Is.Null); // The user should no longer exist
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }
    }
    public class TaskItemTests
    {
        private ApplicationDbContext _dbContext;
        private TaskItemService _taskItemService;
        private TaskItem dummyTaskItem = new Assignment
        {
            UserId = 1,
            SubjectID = "41233",
            SubjectName = "TestSubjectName",
            Date = DateTime.Now,
            TaskItemTitle = "Dummy title",
            Description = "Description",
            Discriminator = "Assignment",
            Percentage = 100,
            TotalMark = 100,
            AchievedMark = 100,
        };

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            _taskItemService = new TaskItemService(_dbContext);
        }

        [Test]
        public async Task AddTaskItemTest()
        {
            

            var addedTaskItem = await _taskItemService.AddTaskItem(dummyTaskItem);

            Assert.IsNotNull(addedTaskItem);
            Assert.That(addedTaskItem.Id, Is.EqualTo(1));
            Assert.That(addedTaskItem.SubjectID, Is.EqualTo(dummyTaskItem.SubjectID));
            Assert.That(addedTaskItem.SubjectName, Is.EqualTo(dummyTaskItem.SubjectName));
            Assert.That(addedTaskItem.Date, Is.EqualTo(dummyTaskItem.Date));
            Assert.That(addedTaskItem.TaskItemTitle, Is.EqualTo(dummyTaskItem.TaskItemTitle));
            Assert.That(addedTaskItem.Description, Is.EqualTo(dummyTaskItem.Description));
            Assert.That(addedTaskItem.Discriminator, Is.EqualTo(dummyTaskItem.Discriminator));
        }
        [Test]
        public async Task GetTaskItem()
        {
            await _taskItemService.AddTaskItem(dummyTaskItem);

            var addedTaskItem = await _taskItemService.GetById(1);

            Assert.IsNotNull(addedTaskItem);
        }
        [Test]
        public async Task DeleteTaskItemTest()
        {

            bool isDeleted = await _taskItemService.DeleteTaskItem(dummyTaskItem);
            Assert.IsTrue(isDeleted);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }
    }
}
