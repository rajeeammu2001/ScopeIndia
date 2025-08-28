using Microsoft.AspNetCore.Mvc;
using ScopeIndia.Data;
using ScopeIndia.Models;

namespace ScopeIndia.Controllers
{
    public class HeroController : Controller
    {
        public IActionResult Index()
        {
            var hero = new Hero
            {
                Heading = "Your career partner!",
                SubHeading = "Center for Software, Networking, & Cloud Education",
                Description = "Dreaming about a career in IT",
                Features = new string[]
                {
                    "Software Programming",
                    "Data Science & AI",
                    "Data Analytics",
                    "Cloud Computing",
                    "Mobile App Development",
                    "DevOps",
                    "Software Testing",
                    "Server Administration",
                    "Networking",
                    "Digital Marketing"
                }
            };

            return View(hero);
        }
    }
}
