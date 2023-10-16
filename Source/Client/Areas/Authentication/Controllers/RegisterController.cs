using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
