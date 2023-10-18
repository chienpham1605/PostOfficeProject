using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
