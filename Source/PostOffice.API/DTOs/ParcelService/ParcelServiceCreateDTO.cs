namespace PostOffice.API.DTOs.ParcelService
{
    public class ParcelServiceCreateDTO
    {
        public string? name { get; set; }
        public string? description { get; set; }

        public string? status { get; set; }

        public int? delivery_time { get; set; }
    }
}
