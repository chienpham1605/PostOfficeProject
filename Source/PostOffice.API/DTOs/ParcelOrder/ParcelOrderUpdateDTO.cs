namespace PostOffice.API.DTOs.ParcelOrder
{
    public class ParcelOrderUpdateDTO
    {
        public string? order_status { get; set; }

        //datetime infor
        public DateTime send_date { get; set; }
        public DateTime receive_date { get; set; }

        //charge infor
        public float? vpp_value { get; set; }
        public float? total_charge { get; set; }
    }
}
