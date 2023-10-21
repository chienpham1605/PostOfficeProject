using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.DTOs.User
{
    public class UserRegisterDTO
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string Username { get; set; }
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public DateTime Create_date { get; set; }
        
    }
}
