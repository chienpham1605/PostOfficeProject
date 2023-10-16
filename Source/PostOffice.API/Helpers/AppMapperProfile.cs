using AutoMapper;
using PostOffice.API.Data.DTOs.MoneyOrder;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.Area;
using PostOffice.API.DTOs.Branch;
using PostOffice.API.DTOs.MoneyOrder;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelService;
using PostOffice.API.DTOs.ParcelServicePrice;
using PostOffice.API.DTOs.ParcelType;
using PostOffice.API.DTOs.Pincode;
using PostOffice.API.DTOs.WeightScope;

namespace PostOffice.API.Helpers
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<PincodeBaseDTO, Pincode>();
            CreateMap<AreaBaseDTO, Area>().ReverseMap(); ;
            CreateMap<AreaCreateDTO, Area>();
            CreateMap<AreaUpdateDTO, Area>();
            CreateMap<OfficeBranch, OfficeBranchBaseDTO>();

            CreateMap<WeightScopeBaseDTO, WeightScope>();
            CreateMap<WeightScopeCreateDTO, WeightScope>();
            CreateMap<WeightScopeUpdateDTO, WeightScope>();

            CreateMap<ServicePriceBaseDTO, ParcelServicePrice>();
            CreateMap<ParcelServiceBaseDTO, ParcelService>();
            CreateMap<ParcelServiceCreateDTO, ParcelService>();

            CreateMap<ParcelTypeBaseDTO, ParcelType>();
            CreateMap<ParcelTypeCreateDTO, ParcelType>();
            CreateMap<ParcelTypeUpdateDTO, ParcelType>();

            CreateMap<ParcelOrderBase, ParcelOrder>();
            CreateMap<ParcelOrderCreateDTO, ParcelOrder>();
            CreateMap<ParcelOrderUpdateDTO, ParcelOrder>();

            CreateMap<ServicePriceCreateDTO, ParcelServicePrice>();
            CreateMap<ServicePriceUpdateDTO, ParcelServicePrice>();

            CreateMap<MoneyOrderBaseDTO, MoneyOrder>();
            CreateMap<MoneyOrderCreateDTO, MoneyOrder>();
            CreateMap<MoneyOrderUpdateDTO, MoneyOrder>();


        }
    }
}
