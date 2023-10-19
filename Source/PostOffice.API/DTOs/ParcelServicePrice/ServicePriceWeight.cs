using PostOffice.API.DTOs.WeightScope;

namespace PostOffice.API.DTOs.ParcelServicePrice
{
    public class ServicePriceWeight
    {
        public int parcel_price_id { get; set; }
        public int scope_weight_id { get; set; }
        public float service_price { get; set; }

        public WeightScopeBaseDTO WeightScope { get; set; }
    }
}
