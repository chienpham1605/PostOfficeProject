using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs;
using PostOffice.API.DTOs.MoneyOrder;
using PostOffice.API.DTOs.MoneyScope;
using PostOffice.API.DTOs.MoneyServicePrice;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelService;
using PostOffice.API.DTOs.ParcelServicePrice;
using PostOffice.API.DTOs.ParcelType;
using PostOffice.API.DTOs.Pincode;
using PostOffice.API.DTOs.WeightScope;
using PostOffice.API.Repositories.ParcelOrder;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "customer")]
    public class ParcelOrderController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _httpClient;
        private readonly string parcelOrderURL = "https://localhost:7053/api/ParcelOrder/";
        private readonly string pincodeURL = "https://localhost:7053/api/Pincode/";
        private readonly string parcelServiceURL = "https://localhost:7053/api/ParcelService/";
        private readonly string weightScopeURL = "https://localhost:7053/api/WeightScopes/";
        private readonly string parcelServicePriceURL = "https://localhost:7053/api/ParcelServicePrice/";
        private readonly string parcelTypeURL = "https://localhost:7053/api/ParcelTypes/";

        public ParcelOrderController() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<ParcelOrderBase> parcelOrders = new List<ParcelOrderBase>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelOrder/GetAllOrders");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    parcelOrders = JsonConvert.DeserializeObject<List<ParcelOrderBase>>(data);
                }
                else
                {
                    throw new Exception("Error Message");
                }
            }
            catch (Exception ex)
            {
                
            }
            return View(parcelOrders);
        }
        [Authorize(Roles = "customer")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewData["StreetAddress"] = User.FindFirst(ClaimTypes.StreetAddress)?.Value;
            ViewData["Email"] = User.FindFirst(ClaimTypes.Email).Value;
            ViewData["PhoneNumber"] = User.FindFirst(ClaimTypes.MobilePhone)?.Value;
            ViewData["LastName"] = User.FindFirst(ClaimTypes.Name)?.Value;
            ViewData["FirstName"] = User.FindFirst(ClaimTypes.GivenName)?.Value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ParcelOrderCreateDTO parcelorder)
        {
            parcelorder.user_id = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            parcelorder.sender_name = User.FindFirst(ClaimTypes.Name)?.Value + " " + User.FindFirst(ClaimTypes.GivenName)?.Value;
            parcelorder.sender_email = User.FindFirst(ClaimTypes.Email).Value;
            parcelorder.sender_address = User.FindFirst(ClaimTypes.StreetAddress)?.Value;
            parcelorder.sender_phone = User.FindFirst(ClaimTypes.MobilePhone)?.Value;

            parcelorder.send_date = DateTime.Now;
            parcelorder.receive_date = DateTime.Now.AddDays(5);
            parcelorder.order_status = 1;

            var test = _httpClient.PostAsJsonAsync<ParcelOrderCreateDTO>(parcelOrderURL, parcelorder).Result;
            return Json(new{ });
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Shipping(int id)
        {
            try
            {
                ParcelOrderBase parcelOrder = new ParcelOrderBase();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelOrder/GetParcelOrderById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    parcelOrder = JsonConvert.DeserializeObject<ParcelOrderBase>(data);

                }
                return View(parcelOrder);
            }
            catch (Exception ex)
            {

                return View();
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Calculate(ParcelOrderCreateDTO parcelOrder)
        //{
        //    var calculation = new Calculation
        //    {
        //        weight = (float)parcelOrder.parcel_weight,
        //        parcel_type_id = parcelOrder.parcel_type_id,
        //        service_id = parcelOrder.service_id,
        //        sender_pincode = parcelOrder.sender_pincode,
        //        receiver_pincode = parcelOrder.receiver_pincode
        //    };

        //    string data = JsonConvert.SerializeObject(calculation);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Calculation/CalculationFee", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var resultString = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<double>(resultString);
        //        parcelOrder.total_charge = (float)result;
        //    }
        //    else
        //    {
        //        throw new Exception("NO data");
        //    }
        //    return View(parcelOrder);
        //}
        [HttpPost]
        public async Task<IActionResult> ScopeFilter(double weight, string sender_pincode, string receiver_pincode, int parcel_type_id, int service_id)
        {
            var service = JsonConvert.DeserializeObject<ParcelServiceBaseDTO>(await _httpClient.GetStringAsync(parcelServiceURL + "GetServiceById?id=" + service_id));
            var parcelType = JsonConvert.DeserializeObject<ParcelTypeBaseDTO>(await _httpClient.GetStringAsync(parcelTypeURL + "GetParcelTypeById?id=" + parcel_type_id));
            int zone_id;
            
            if (sender_pincode == receiver_pincode && sender_pincode != null && receiver_pincode != null)
            {
                zone_id = 1;
            }
            else
            {
                int send_area = JsonConvert.DeserializeObject<PincodeBaseDTO>(_httpClient.GetStringAsync(pincodeURL + "PincodeById?id=" + sender_pincode).Result)!.area_id;
                int rec_area = JsonConvert.DeserializeObject<PincodeBaseDTO>(_httpClient.GetStringAsync(pincodeURL + "PincodeById?id=" + receiver_pincode).Result)!.area_id;
                if (send_area != rec_area)
                {
                    zone_id = 3;
                }
                else
                {
                    zone_id = 2;
                }
            }
            var weightScope = JsonConvert.DeserializeObject<WeightScopeBaseDTO>(_httpClient.GetStringAsync(weightScopeURL + "getWeightRange?weight=" + weight).Result);

            // Lấy thông tin về giá dịch vụ
            var priceResponse = _httpClient.GetStringAsync(parcelServicePriceURL + "ZoneNScope" + "?zone=" + zone_id.ToString() + "&scope=" + weightScope.id.ToString() + "&service=" + service.service_id.ToString() + "&parcelType=" + parcelType.id.ToString()).Result;

            ServicePriceBaseDTO? servicePrice = JsonConvert.DeserializeObject<ServicePriceBaseDTO>(priceResponse);

            // Tính toán total_charge
            float total_charge = 0;
            if (servicePrice != null)
            {
                total_charge = (float)(weight + servicePrice.service_price);
            }

            return Json(new { total_charge = total_charge });
        }
        public IActionResult submit(string successful)
        {
            return View();
        }
    }
}
