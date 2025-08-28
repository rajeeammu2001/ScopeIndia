using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScopeIndia.Data;
using ScopeIndia.Models;

namespace ScopeIndia.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly MVCDBContext _context;

        public StudentDashboardController(MVCDBContext context)
        {
            _context = context;
        }

        // Dashboard view
        public IActionResult Dashboard()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
                return RedirectToAction("Login", "Login");

            var student = _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefault(s => s.Id == studentId);

            if (student == null)
                return RedirectToAction("Login", "Login");

            var allCourses = _context.Courses.ToList();

            var viewModel = new DashboardViewModel
            {
                StudentName = student.FullName,
                Email = student.Email,
                PickedCourses = student.StudentCourses.Select(sc => sc.Course).ToList(),
                AvailableCourses = allCourses
                    .Where(c => !student.StudentCourses.Any(sc => sc.CourseId == c.Id))
                    .ToList()
            };

            return View("~/Views/StudentDashboard/Dashboard.cshtml", viewModel);
        }

        // Profile page
        public IActionResult Profile()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
                return RedirectToAction("Login", "Login");

            var student = _context.Students
    .Include(s => s.StudentCourses)
        .ThenInclude(sc => sc.Course)
    .FirstOrDefault(s => s.Id == studentId);

            if (student == null)
                return RedirectToAction("Login", "Login");

            //return View("~/Views/StudentDashboard/Profile.cshtml", student);
            return View("~/Views/Registration/Profile.cshtml", student);

        }


        [HttpPost]
         // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("StudentId");
            Response.Cookies.Delete("LoginEmail");
            Response.Cookies.Delete("LoginName");
            return RedirectToAction("Login", "Login");
        }



    }
}

