using Microsoft.AspNetCore.Mvc;
namespace PostOffice.API.Controllers
{
    public class CustomerManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
