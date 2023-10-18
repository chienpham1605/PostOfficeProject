using PostOffice.API.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.DTOs.MoneyOrder
{
    public class MoneyOrderUpdateDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        public TransferStatus transfer_status { get; set; }
    }
}
