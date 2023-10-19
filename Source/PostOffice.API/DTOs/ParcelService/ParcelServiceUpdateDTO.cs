using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.DTOs.ParcelService
{
    public class ParcelServiceUpdateDTO
    {
        [Required]
        public string? status { get; set; }
        [Required]
        
        public int? delivery_time { get; set; }
    }
}
