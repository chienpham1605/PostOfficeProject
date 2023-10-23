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

using PostOffice.API.Repositorities.Pincode;


namespace PostOffice.API.Controllers
{
    [Route("api/[controller]/[action]")]
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


        }

        [HttpGet]
        public async Task<IActionResult> GetPincodes()
        {
            var pincodeDtos = await _repository.GetPincodes();
            if (pincodeDtos.Count() <= 0)
            {
                return NotFound();
            }
            return Ok(pincodeDtos);

        }

    }
}
