using PostOffice.API.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.DTOs.ParcelService
{
    public class ParcelServiceUpdateDTO
    {
        [Required]
        public ServiceStatus status { get; set; }
        [Required]
        
        public int? delivery_time { get; set; }
    }
}
