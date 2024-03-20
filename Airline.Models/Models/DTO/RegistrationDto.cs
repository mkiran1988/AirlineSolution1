using System.ComponentModel.DataAnnotations;


namespace Airline.API.Models.DTO
{
    public class RegistrationDto :IValidatableObject
    {

        [Required(ErrorMessage ="First name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(this.Password) || string.IsNullOrEmpty(this.ConfirmPassword) ||
           string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Password) || string.IsNullOrEmpty(this.Password))
            {
                yield return new ValidationResult("Error in request payload.Please make sure you have supplied information for all fields");
            }
        }
    }
}
