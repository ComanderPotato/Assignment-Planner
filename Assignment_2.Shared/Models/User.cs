using Assignment_2.Shared.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Shared.Models
{
    // User class with variables related to the User object.
    // Parameters explained:
    // - [key]: Defines the primary key.
    // - [Required]: Used in form validation, if input is empty outputs the following ErrorMessage.
    // - [StringLength]: Validates on a specified StringLength, if it exceeds outputs the following ErrorMessage.
    // - [RegularExpression]: Validates based on a RegularExpression, ouputs following ErrorMessage.
    // - [PasswordValidation]: See Assignment_2.Shared/Utilities/Validation, too many areas to validate and the line was too big if
    //   done that others. Essentially it validates areas individually, and outputs the ErrorMessage based on which one was encountered
    //   first. Helps to minimize the ErrorMessage length.
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"(\w*@)(?:outlook|gmail|uts).com$", ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [PasswordValidation]
        public string Password { get; set; } = string.Empty;
        public virtual List<TaskItem> Assignments { get; set; } = new List<TaskItem>();

        public User()
        {

        }
    }
}
