﻿using AutoMapper;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.Area;
using PostOffice.API.DTOs.Branch;
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
            CreateMap<PincodeBaseDTO, Pincode>().ReverseMap();

            CreateMap<AreaBaseDTO, Area>().ReverseMap(); 
            CreateMap<AreaCreateDTO, Area>();
            CreateMap<AreaUpdateDTO, Area>();
            CreateMap<OfficeBranch, OfficeBranchBaseDTO>();

            CreateMap<WeightScopeBaseDTO, WeightScope>().ReverseMap();
            CreateMap<WeightScopeCreateDTO, WeightScope>();
            CreateMap<WeightScopeUpdateDTO, WeightScope>();

            CreateMap<ServicePriceBaseDTO, ParcelServicePrice>().ReverseMap();

            CreateMap<ServicePriceCreateDTO, ParcelServicePrice>();
            CreateMap<ServicePriceUpdateDTO, ParcelServicePrice>();

            
            CreateMap<ParcelService, ParcelServiceBaseDTO>().ReverseMap(); 
            CreateMap<ParcelServiceCreateDTO, ParcelService>();
            CreateMap<ParcelServiceUpdateDTO, ParcelService>().ReverseMap();

            CreateMap<ServicePriceBaseDTO, ParcelServicePrice>().ReverseMap();
            CreateMap<ServicePriceCreateDTO, ParcelServicePrice>().ReverseMap();
            CreateMap<ServicePriceUpdateDTO, ParcelServicePrice>().ReverseMap();

            CreateMap<ParcelOrderFeeShippingDTO, ParcelOrder>().ReverseMap();

            CreateMap<ParcelTypeBaseDTO, ParcelType>().ReverseMap();
            CreateMap<ParcelTypeCreateDTO, ParcelType>();
            CreateMap<ParcelTypeUpdateDTO, ParcelType>();

            CreateMap<ParcelOrderBase, ParcelOrder>().ReverseMap();
            CreateMap<ParcelOrder, ParcelOrderCreateDTO>().ReverseMap();
            CreateMap<ParcelOrderUpdateDTO, ParcelOrder>().ReverseMap();

        }
    }
}
