using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostOffice.API.Data.Context;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.Area;
using PostOffice.API.DTOs.ParcelService;
using PostOffice.API.DTOs.ParcelServicePrice;
using PostOffice.API.DTOs.ParcelType;
using PostOffice.API.Repositories.ParcelServicePrice;

namespace PostOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelServicePriceController : ControllerBase
    {
        private readonly IServicePriceRepository _repository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public ParcelServicePriceController(IServicePriceRepository repository, AppDbContext context, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicePriceBaseDTO>>> GetAreas()
        {
            if (_context.ServicePrices == null)
            {
                return NotFound();
            }
            var servicesPrices = await _context.ServicePrices.ToListAsync();
            var records = _mapper.Map<List<ServicePriceBaseDTO>>(servicesPrices);
            return Ok(records);
        }
        [HttpPost]
        public async Task<IActionResult> AddServicePrice([FromBody] ServicePriceCreateDTO servicePriceCreateDTO)
        {
            await _repository.AddServicePrice(servicePriceCreateDTO);
            return Ok(servicePriceCreateDTO);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateServicePrice(int id,[FromBody] ServicePriceUpdateDTO servicePriceUpdateDTO)
        {
            var feeUpdated = await _repository.UpdateServicePrice(id, servicePriceUpdateDTO);

            if (!feeUpdated)
            {
                return NotFound();
            }

            return NoContent();

        }

    }
}
