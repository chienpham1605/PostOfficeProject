using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostOffice.API.Repositories.MoneyOrder;
using PostOffice.API.Repositorities.Pincode;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PostOffice.API.Data.Context;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.ParcelServicePrice;
using PostOffice.API.DTOs.Pincode;
using System.Net.Http;
using System.Security.Policy;

namespace PostOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : ControllerBase
    {
        private readonly IPincodeRepository _repository;
        public PincodeController(IPincodeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("PincodeById", Name= "GetPincodebyId")]
        public async Task<IActionResult> GetPincodeById(string id)
        {
            var pincodeDto = await _repository.GetPincodeById(id);
            if(pincodeDto == null)
            {
                return NotFound();
            }
            return Ok(pincodeDto);

        }

        [HttpGet("PincodeList",Name = "GetPincodes")]
        public async Task<IActionResult> GetPincodes()
        {
            var pincodeDtos = await _repository.GetPincodes();
            if (pincodeDtos.Count() <= 0)
            {
                return NotFound();
            }
            return Ok(pincodeDtos);

        }
        //[HttpGet("ScopeFilter")]
        //public async Task<IActionResult> ScopeFilter( string sendPin, string recPin)
        //{
        //    // Calculate money scope and zone type dbo.moneyservice
        //    ZoneType zone_type_id;
        //    float total_charge;

        //    var sender = await _context.Pincodes.FirstOrDefaultAsync(p => p.pincode == sendPin);
        //    var receiver = await _context.Pincodes.FirstOrDefaultAsync(p => p.pincode == recPin);

        //    if (sender == null || receiver == null)
        //    {
        //        return NotFound();
        //    }

        //    if (sender.pincode == receiver.pincode)
        //    {
        //        zone_type_id = 1;
        //    }
        //    else if (sender.area_id != receiver.area_id)
        //    {
        //        zone_type_id = 3;
        //    }
        //    else
        //    {
        //        zone_type_id = 2;
        //    }

        //    return Ok();
        //}

    }
}
