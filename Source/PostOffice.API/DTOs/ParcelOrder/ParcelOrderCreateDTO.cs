using PostOffice.API.Data.Enums;
using PostOffice.API.DTOs.Pincode;

namespace PostOffice.API.DTOs.ParcelOrder
{
    public class ParcelOrderCreateDTO
    {
        //personal infor
        //personal infor
        public string? sender_name { get; set; }
        public string? sender_pincode { get; set; }
        public string? sender_address { get; set; }
        public string? sender_phone { get; set; }
        public string? sender_email { get; set; }
        public string? description { get; set; }
        public string? note { get; set; }

        public string? receiver_name { get; set; }
        public string? receiver_pincode { get; set; }
        public string? receiver_address { get; set; }
        public string? receiver_phone { get; set; }
        public string? receiver_email { get; set; }
        public float? parcel_length { get; set; }
        public float? parcel_height { get; set; }
        public float? parcel_width { get; set; }
        public float? parcel_weight { get; set; }

        //payment infor
        public string? payer { get; set; }
        public string? payment_method { get; set; }
        
        public int parcel_type_id { get; set; }
        public TransferStatus order_status { get; set; }
        //datetime infor
        public DateTime send_date { get; set; }
        public DateTime receive_date { get; set; }
       


    }
}
