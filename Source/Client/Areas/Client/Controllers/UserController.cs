using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
