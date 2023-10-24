using PostOffice.API.Data.Enums;

namespace PostOffice.API.DTOs.ParcelOrder
{
    public class ParcelOrderUpdateDTO
    {
        public int order_status { get; set; }

        //datetime infor
        public DateTime send_date { get; set; }
        public DateTime receive_date { get; set; }

        //charge infor
        public float? vpp_value { get; set; }
    }
}
