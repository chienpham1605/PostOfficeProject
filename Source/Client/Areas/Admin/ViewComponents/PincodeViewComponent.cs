
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelType;
using PostOffice.API.DTOs.Pincode;
using PostOffice.API.Repositorities.Pincode;
using System.Net.Http;

namespace PostOffice.Client.Areas.Client.ViewComponents
{
    public class PincodeViewComponent : ViewComponent
    {
        private readonly string pincodeURL = "https://localhost:7053/api/Pincode/";
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _httpClient;
        public PincodeViewComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IViewComponentResult Invoke()
        {
            List<PincodeBaseDTO>? typeList = JsonConvert.DeserializeObject<List<PincodeBaseDTO>>(
                               _httpClient.GetStringAsync(pincodeURL + "GetPincodes").Result
                           );

            return View(typeList);
        }
    }
}
