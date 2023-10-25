using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs;
using PostOffice.API.DTOs.MoneyOrder;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelServicePrice;
using PostOffice.API.DTOs.ParcelType;
using PostOffice.API.DTOs.Pincode;
using PostOffice.API.Repositories.ParcelOrder;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class ParcelOrderController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _httpClient;
        private readonly string parcelOrderURL = "https://localhost:7053/api/ParcelOrder/";
       
        public ParcelOrderController() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewData["StreetAddress"] = User.FindFirst(ClaimTypes.StreetAddress)?.Value;
            ViewData["Email"] = User.FindFirst(ClaimTypes.Email).Value;
            ViewData["PhoneNumber"] = User.FindFirst(ClaimTypes.MobilePhone)?.Value;
            ViewData["LastName"] = User.FindFirst(ClaimTypes.Name)?.Value;
            ViewData["FirstName"] = User.FindFirst(ClaimTypes.GivenName)?.Value;

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

            string data = JsonConvert.SerializeObject(parcelorder);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/ParcelOrder/AddParcelOrder", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ParcelOrder");
            }
            return View(parcelorder);
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
        [HttpPost]
        public async Task<IActionResult> Calculate(ParcelOrderCreateDTO parcelOrder)
        {
            var calculation = new Calculation
            {
                weight = (float)parcelOrder.parcel_weight,
                parcel_type_id = parcelOrder.parcel_type_id,
                service_id = parcelOrder.service_id,
                sender_pincode = parcelOrder.sender_pincode,
                receiver_pincode = parcelOrder.receiver_pincode
            };

            string data = JsonConvert.SerializeObject(calculation);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Calculation/CaculationFee", content);

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<double>(resultString);
                parcelOrder.total_charge = (float)result;
            }
            else
            {
                throw new Exception("NO data");
            }
            return (IActionResult)parcelOrder;
        }
    }
}
