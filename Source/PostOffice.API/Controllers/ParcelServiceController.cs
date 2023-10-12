using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.ParcelService;
using PostOffice.API.Repositories.ParcelOrder;
using PostOffice.API.Repositories.ParcelService;

namespace PostOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelServiceController : ControllerBase
    {
        private readonly IParcelServiceRepository _repository;
        private readonly IMapper _mapper;
        public ParcelServiceController(IParcelServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        [HttpGet("products")]
        public async Task<IActionResult> GetAllService()
        {
            var parcelservices = await _repository.GetParcelServiceList();

            return Ok(parcelservices);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ParcelServiceCreateDTO parcelServiceCreateDto)
        {
            await _repository.AddParcelService(parcelServiceCreateDto);
            return Ok(parcelServiceCreateDto);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParcelService(int id, [FromBody] ParcelServiceUpdateDTO parcelServiceUpdateDTO)
        {
            var affectedResult = await _repository.UpdateParcelService(id, parcelServiceUpdateDTO);
            if (affectedResult == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
