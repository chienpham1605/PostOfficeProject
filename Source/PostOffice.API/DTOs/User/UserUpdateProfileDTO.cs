namespace PostOffice.API.DTOs.User
{
    public class UserUpdateProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }           
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }        
       
    }
}
