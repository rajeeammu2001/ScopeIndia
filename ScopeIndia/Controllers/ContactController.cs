using Microsoft.AspNetCore.Mvc;
using ScopeIndia.Data;

namespace ScopeIndia.Controllers
{
    public class ContactController : Controller
    {
        private readonly MVCDBContext _context;

        public ContactController(MVCDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var locations = _context.ContactLocations.ToList();
            return View(locations);
        }
    }
}
