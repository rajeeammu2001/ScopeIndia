using Microsoft.AspNetCore.Mvc;

namespace ScopeIndia.Controllers
{
    public class PlacementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
