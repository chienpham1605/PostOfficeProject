using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.DTOs.User
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Please enter the first name")]
        [StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Length must be between 10 to 25")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Please enter the last name")]
        public string LastName { get; set; } = null!;
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress(ErrorMessage = "Please enter a valid email")]            
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is a required field.")]             
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Confirm password is a required field.")]
        [Compare("Password", ErrorMessage = "The new password and confirm password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public string PincodeId { get; set; }
        [Required]
        public string Address { get; set; }
        [Phone(ErrorMessage = "Please enter a valid Phone No")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public DateTime Create_date { get; set; }

        public string Role { get; set; }


    }
}
