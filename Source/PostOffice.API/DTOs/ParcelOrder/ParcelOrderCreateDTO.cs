﻿using PostOffice.API.Data.Enums;
using PostOffice.API.DTOs.Pincode;
using System.ComponentModel.DataAnnotations;

namespace PostOffice.API.DTOs.ParcelOrder
{
    public class ParcelOrderCreateDTO
    {

        [Required]
        public Guid user_id { get; set; }

        public string? sender_name { get; set; }
        [Required]
        public string? sender_pincode { get; set; }
        [Required]
        public string? sender_address { get; set; }
        [Required]
        [Range(9,12, ErrorMessage = "Phone should be between 9 and 12 digits")]
        public string? sender_phone { get; set; }
        [Required]
        [EmailAddress]
        public string? sender_email { get; set; }
        public string? description { get; set; }
        public string? note { get; set; }

        [Required]
        public string? receiver_name { get; set; }
        public string? receiver_pincode { get; set; }
        [Required]
        public string? receiver_address { get; set; }
        [Required]
        [Range(9, 12, ErrorMessage = "Phone should be between 9 and 12 digits")]

        public string? receiver_phone { get; set; }
        [Required]
        [EmailAddress]
        public string? receiver_email { get; set; }
        [Required]
        public float? parcel_length { get; set; }
        [Required]
        public float? parcel_height { get; set; }
        [Required]
        public float? parcel_width { get; set; }
        [Required]
        public float? parcel_weight { get; set; }

        //payment infor
        public string? payer { get; set; }
        public string? payment_method { get; set; }
        public int service_id { get; set; }
        public int parcel_type_id { get; set; }
        public int order_status { get; set; }
        //datetime infor
        public DateTime send_date { get; set; }
        public DateTime receive_date { get; set; }
       


    }
}
