using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.DTOs.MoneyOrder;
using PostOffice.API.DTOs.Pincode;
using System.Text.Json.Serialization;

namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class StatisticController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private readonly string moneyorderURL = "https://localhost:7053/api/MoneyOrder/";
        public IActionResult Index()
        {
            List<MoneyOrderBaseDTO>? statistic = JsonConvert.DeserializeObject<List<MoneyOrderBaseDTO>>(
                             httpClient.GetStringAsync(moneyorderURL + "MoneyorderList").Result);
            return View("Statistic", statistic);

        }
        [HttpPost]
        public IActionResult Statistic(string option)
        {


            return View();
        }


    }
}
