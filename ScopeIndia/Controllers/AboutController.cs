using Microsoft.AspNetCore.Mvc;
using ScopeIndia.Data;

namespace ScopeIndia.Controllers
{
    public class AboutController : Controller
    {
        private readonly MVCDBContext _context;

        public AboutController(MVCDBContext context)
        {
            _context = context;
        }

        public IActionResult AboutUs()
        {
            var sections = _context.AboutUsSections.ToList();
            var stats = _context.AboutUsStats.ToList();
            ViewBag.Sections = sections;
            ViewBag.Stats = stats;
            return View();
        }
    }
}
