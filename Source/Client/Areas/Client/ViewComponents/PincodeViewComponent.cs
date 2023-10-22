
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.Pincode;
using PostOffice.API.Repositorities.Pincode;
using System.Net.Http;

namespace PostOffice.Client.Areas.Client.ViewComponents
{
    public class PincodeViewComponent : ViewComponent
    {
        private readonly IPincodeRepository _repository;
       
        public PincodeViewComponent(IPincodeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pincodeDtos = await _repository.GetPincodes();

            return View(pincodeDtos);
        }
    }
}
