    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System;
    using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace PostOffice.API.Repositories.ParcelOrder
{
    using PostOffice.API.Data.Models;
    using PostOffice.API.Data.Context;
    using PostOffice.API.DTOs.ParcelOrder;
    using Microsoft.AspNetCore.Mvc;


    public class ParcelOrderService : IParcelOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ParcelOrderService(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ParcelOrder> AddParcelOrderAsync(ParcelOrderCreateDTO parcelOrderDTO)
        {
            var parcelOrder = _mapper.Map<ParcelOrder>(parcelOrderDTO);

            _context.ParcelOrders.AddAsync(parcelOrder);
             await _context.SaveChangesAsync();
            return parcelOrder;
        }

        public async Task<ParcelOrderBase> GetParcelOrderById(int id)
        {
                var parcelOrder = await _context.ParcelOrders.FindAsync(id);
                var parcelOrderDto = _mapper.Map<ParcelOrderBase>(parcelOrder);

                return parcelOrderDto;

        }

        public async Task<bool> UpdateParcelOrder(int id, ParcelOrderUpdateDTO parcelOrderUpdateDTO)
        {
            var parcelorders = _context.ParcelOrders.SingleOrDefault(p => p.id == id);

            if (parcelorders == null)
            {
                return false;
            }
             _mapper.Map(parcelOrderUpdateDTO, parcelorders);

             _context.SaveChanges();

            return true;
        }
    }
}
