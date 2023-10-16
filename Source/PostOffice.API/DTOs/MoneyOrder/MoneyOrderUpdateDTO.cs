using PostOffice.API.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.Data.DTOs.MoneyOrder
{
    public class MoneyOrderUpdateDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        public TransferStatus transfer_status { get; set; }
    }
}
