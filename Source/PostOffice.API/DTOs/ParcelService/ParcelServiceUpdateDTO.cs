using PostOffice.API.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.DTOs.ParcelService
{
    public class ParcelServiceUpdateDTO
    {
        public int delivery_time { get; set; }
    }
}
