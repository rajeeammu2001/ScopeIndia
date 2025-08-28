using System.Net.Mail;
using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using ScopeIndia.Models;
using ScopeIndia.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ScopeIndia.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MVCDBContext _context;

        public RegistrationController(MVCDBContext context)
        {
            _context = context;
        }

        // GET: Registration form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Save registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Student model, string[] PreferredTimings)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    // Save preferred timings as comma-separated
                    model.PreferredTimingsDb = PreferredTimings != null ? string.Join(", ", PreferredTimings) : "";

                    // Email confirmation token
                    model.EmailConfirmationToken = Guid.NewGuid().ToString();
                    model.EmailConfirmed = false;

                    // Add student to database
                    _context.Students.Add(model);
                    _context.SaveChanges();

                    // Store studentId in session
                    HttpContext.Session.SetInt32("StudentId", model.Id);

                    // Redirect to Profile page after successful registration
                    return RedirectToAction("Login","Login");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Error saving registration: " + ex.Message;
                }
            //}

            // If validation fails, stay on registration page
            return View(model);
        }

        // GET: Student Profile
        [HttpGet]
        public IActionResult Profile()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                return RedirectToAction("Login", "Login");
            }

            // Get picked courses
            var pickedCourses = _context.StudentCourses
                .Include(sc => sc.Course)
                .Where(sc => sc.StudentId == studentId.Value)
                .Select(sc => sc.Course)
                .ToList();

            ViewBag.PickedCourses = pickedCourses;

            return View(student);
        }




        //new addition
        // Pick a course when clicking Sign Up
        public IActionResult PickCourse(int courseId)
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var course = _context.Courses.Find(courseId);
            if (course == null)
            {
                return NotFound();
            }

            // Check if already picked
            bool alreadyPicked = _context.StudentCourses.Any(sc => sc.StudentId == studentId.Value && sc.CourseId == course.Id);
            if (!alreadyPicked)
            {
                _context.StudentCourses.Add(new StudentCourse
                {
                    StudentId = studentId.Value,
                    CourseId = course.Id
                });
                _context.SaveChanges();
            }

            return RedirectToAction("Profile");
        }
        // Remove a picked course
        public IActionResult RemoveCourse(int courseId)
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var studentCourse = _context.StudentCourses
                .FirstOrDefault(sc => sc.StudentId == studentId.Value && sc.CourseId == courseId);

            if (studentCourse != null)
            {
                _context.StudentCourses.Remove(studentCourse);
                _context.SaveChanges();
            }

            return RedirectToAction("Profile");
        }






    }

}
