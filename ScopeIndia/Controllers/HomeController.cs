using Microsoft.AspNetCore.Mvc;

namespace ScopeIndia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
