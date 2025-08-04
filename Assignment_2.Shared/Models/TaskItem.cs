using Assignment_2.Shared.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Shared.Models
{
    // Parent class TaskItem which gets inherited by Assignment and Homework.
    // Parameters explained:
    // - [key]: Defines the primary key.
    // - [ForeignKey]: Ughhh- idk i'll get back to you on that.
    // - [Required]: Used in form validation, if input is empty outputs the following ErrorMessage.
    // - [DateValidationAttribute: See Assignment_2.Shared/Utilities/Validation, extra validation making sure Date > DateTime.Now.
    // - [RegularExpression]: Validates based on a RegularExpression, ouputs following ErrorMessage.
    // - [Range]: Validates a number is between a specific Range, outputs following ErrorMessage.
    public class TaskItem
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public required int UserId { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        [DateValidationAttribute]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Subject ID is required")]
        [RegularExpression("^[0-9]{5,10}$", ErrorMessage = "Subject ID must be between 5 and 10 digits and contain only numbers")]
        public string SubjectID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subject Name is required")]
        public string SubjectName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Task Title is required")]
        public string TaskItemTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Discriminator { get; set; } = string.Empty;
        public TaskItem() { }
        public TaskItem(int userId, DateTime date, string subjectID, string subjectName, string taskItemTitle, string description)
        {
            UserId = userId;
            Date = date;
            SubjectID = subjectID;
            SubjectName = subjectName;
            TaskItemTitle = taskItemTitle;
            Description = description;
        }
    }

    public class HomeWork : TaskItem
    {
        public HomeWork() { }
        public HomeWork(int userId,
                        DateTime date,
                        string subjectID,
                        string subjectName,
                        string taskItemTitle,
                        string description) : base(userId, date, subjectID, subjectName, taskItemTitle, description)
        {
            Discriminator = nameof(HomeWork);
        }
    }

    public class Assignment : TaskItem
    {

        [Required(ErrorMessage = "Percentage is required.")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
        public float Percentage { get; set; }

        [Required(ErrorMessage = "Achieved Mark is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Achieved Mark must be a non-negative value.")]
        public float AchievedMark { get; set; }

        [Required(ErrorMessage = "Total Mark is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Total Mark must be a non-negative value.")]
        public float TotalMark { get; set; }

        public Assignment() { }
        public Assignment(int userId,
                          DateTime date,
                          string subjectID,
                          string subjectName,
                          string taskItemTitle,
                          string description,
                          float percentage,
                          float achievedMark,
                          float totalMark) : base(userId, date, subjectID, subjectName, taskItemTitle, description)
        {
            Percentage = percentage;
            AchievedMark = achievedMark;
            TotalMark = totalMark;
            Discriminator = nameof(Assignment);
        }
    }
}
