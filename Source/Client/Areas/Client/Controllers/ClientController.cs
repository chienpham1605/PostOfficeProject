using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class ClientController : Controller
    {
        [HttpGet]
        public IActionResult ParselCreate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MoneyOrder()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Statistic()
        {
            return View();
        }
    }
}
