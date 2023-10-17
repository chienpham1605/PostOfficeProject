using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Login.Controllers
{
    [Area("Authentication")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
