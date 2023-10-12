using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ParselCreate ()
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
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
