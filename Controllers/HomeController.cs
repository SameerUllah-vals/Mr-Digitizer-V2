using Microsoft.AspNetCore.Mvc;

namespace MrDigitizerV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
