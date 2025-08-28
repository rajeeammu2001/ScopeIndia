using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScopeIndia.Data;
using ScopeIndia.Models;

namespace ScopeIndia.Controllers
{
    public class LoginController : Controller
    {
        private readonly MVCDBContext _context;

        public LoginController(MVCDBContext context)
        {
            _context = context;
        }

        #region Login
        [HttpGet]
        public IActionResult Login() => View("~/Views/Login/Login.cshtml");

        [HttpPost]
        public IActionResult Login(string email, string password, string check)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and Password are required.";
                return View("~/Views/Login/Login.cshtml");
            }

            var login = _context.StudentLogins.FirstOrDefault(x =>
                x.Email == email &&
                ((x.Password != null && x.Password == password) ||
                 (x.IsTempPassword && x.TempPassword == password)));

            if (login == null)
            {
                ViewBag.Error = "Invalid Email or Password.";
                return View("~/Views/Login/Login.cshtml");
            }

            var student = _context.Students.FirstOrDefault(s => s.Email == login.Email);
            if (student == null)
            {
                ViewBag.Error = "Student record not found.";
                return View("~/Views/Login/Login.cshtml");
            }

            // First-time login (temporary password)
            if (login.IsTempPassword)
            {
                HttpContext.Session.SetInt32("StudentId", student.Id);
                return RedirectToAction("ChangePassword");
            }

            // Normal login
            HttpContext.Session.SetInt32("StudentId", student.Id);
            HttpContext.Session.SetString("LoginEmail", student.Email);
            HttpContext.Session.SetString("LoginName", student.FullName ?? "Student");

            // Keep me logged in
            if (!string.IsNullOrEmpty(check))
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(6),
                    HttpOnly = true,
                    IsEssential = true
                };
                Response.Cookies.Append("StudentId", student.Id.ToString(), cookieOptions);
                Response.Cookies.Append("LoginEmail", student.Email, cookieOptions);
                Response.Cookies.Append("LoginName", student.FullName ?? "Student", cookieOptions);
            }

            return RedirectToAction("Dashboard", "StudentDashboard");
        }
        #endregion

        #region First Time Login
        [HttpGet]
        public IActionResult FirstTimeLogin() => View("~/Views/Login/FirstTimeLogin.cshtml");

        [HttpPost]
        [HttpPost]
        public IActionResult FirstTimeLogin(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Email is required.";
                return View("~/Views/Login/FirstTimeLogin.cshtml");
            }

            // Case-insensitive search in StudentLogins
            var login = _context.StudentLogins
                        .FirstOrDefault(s => s.Email.ToLower() == email.ToLower());

            // If no login exists, check if student exists and create login
            if (login == null)
            {
                var student = _context.Students
                                .FirstOrDefault(s => s.Email.ToLower() == email.ToLower());

                if (student != null)
                {
                    // Create a new login record for first-time login
                    login = new StudentLogin
                    {
                        Email = student.Email,
                        IsTempPassword = true,
                        TempPassword = Guid.NewGuid().ToString("N").Substring(0, 8)
                    };
                    _context.StudentLogins.Add(login);
                    _context.SaveChanges();

                    // Send temp password
                    EmailService.SendTempPassword(login.Email, login.TempPassword);

                    ViewBag.Success = "Temporary password sent to your email.";
                    return View("~/Views/Login/FirstTimeLogin.cshtml");
                }

                // Email not found anywhere
                ViewBag.Error = "Email not found.";
                return View("~/Views/Login/FirstTimeLogin.cshtml");
            }

            // Existing login found: generate temp password
            login.TempPassword = Guid.NewGuid().ToString("N").Substring(0, 8);
            login.IsTempPassword = true;

            _context.SaveChanges();
            EmailService.SendTempPassword(login.Email, login.TempPassword);

            ViewBag.Success = "Temporary password sent to your email.";
            return View("~/Views/Login/FirstTimeLogin.cshtml");
        }

        #endregion

        #region Change Password
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetInt32("StudentId") == null)
                return RedirectToAction("Login");

            return View("~/Views/Login/ChangePassword.cshtml");
        }

        [HttpPost]
        public IActionResult ChangePassword(string newPassword)
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
                return RedirectToAction("Login");

            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                return RedirectToAction("Login");

            var login = _context.StudentLogins.FirstOrDefault(s => s.Email == student.Email);
            if (login == null)
                return RedirectToAction("Login");

            login.Password = newPassword;
            login.TempPassword = null;
            login.IsTempPassword = false;

            _context.SaveChanges();

            return RedirectToAction("Dashboard", "StudentDashboard");
        }
        #endregion

        #region Forgot Password
        [HttpGet]
        public IActionResult ForgotPassword() => View("~/Views/Login/ForgotPassword.cshtml");

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Email is required.";
                return View("~/Views/Login/ForgotPassword.cshtml");
            }

            var login = _context.StudentLogins.FirstOrDefault(s => s.Email == email);
            if (login == null)
            {
                ViewBag.Error = "Email not found.";
                return View("~/Views/Login/ForgotPassword.cshtml");
            }

            login.TempPassword = Guid.NewGuid().ToString("N").Substring(0, 8);
            login.IsTempPassword = true;

            _context.SaveChanges();
            EmailService.SendTempPassword(login.Email, login.TempPassword);

            ViewBag.Success = "Temporary password sent to your email.";
            return View("~/Views/Login/ForgotPassword.cshtml");
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("StudentId");
            Response.Cookies.Delete("LoginEmail");
            Response.Cookies.Delete("LoginName");
            return RedirectToAction("Login");
        }
        #endregion
    }

    // ✅ Email service for temporary passwords
    public static class EmailService
    {
        public static void SendTempPassword(string email, string tempPassword)
        {
            var fromAddress = new MailAddress("rajeeammu2001@gmail.com", "Scope India");
            var toAddress = new MailAddress(email);
            const string fromPassword = "obza etge cwvv lrka"; // Gmail app password
            const string subject = "Scope India - Temporary Password";
            string body = $"Hello,\n\nYour temporary password is: {tempPassword}\nPlease login and change it immediately.";

            using var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
        }
    }
}

