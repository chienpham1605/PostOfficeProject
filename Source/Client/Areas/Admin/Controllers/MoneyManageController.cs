using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API;
using PostOffice.API.Data.Enums;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.MoneyOrder;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace PostOffice.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoneyManageController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private readonly string moneyorderURL = "https://localhost:7053/api/MoneyOrder/";
        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<MoneyOrderUpdateDTO>? moneymanage = JsonConvert.DeserializeObject<List<MoneyOrderUpdateDTO>>(
                            httpClient.GetStringAsync(moneyorderURL + "MoneyorderList").Result);
            return View(moneymanage);

        }

        [HttpPost]
        public async Task<IActionResult> Detail(int id, string option)

        {
            MoneyOrderUpdateDTO isStatused = new MoneyOrderUpdateDTO();
            isStatused.id = id;
            if (option == "Approve")
            {
                isStatused.transfer_status = TransferStatus.Processing;
            }

            if (option == "Deny")
            {
                isStatused.transfer_status = TransferStatus.Failed;
            }

            var isStatus = await httpClient.PostAsJsonAsync<MoneyOrderUpdateDTO>("https://localhost:7053/api/MoneyOrder/UpdateMoneyManage?isStatus=true", isStatused);

            return RedirectToAction("Index");
        }
    }
}
