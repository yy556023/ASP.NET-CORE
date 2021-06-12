using Lab_Login_Cookie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Login_Cookie.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password) {
            if (string.IsNullOrEmpty(userName)) {
                return View();
            }
            Microsoft.AspNetCore.Http.CookieOptions cookieOptions =
                new Microsoft.AspNetCore.Http.CookieOptions() {
                    HttpOnly = true,
                    // Expires = DateTime.Now.AddDays(14)
                };
            Response.Cookies.Append("userName", userName, cookieOptions);
            return Redirect("/Home/Index");
        }

        public IActionResult MemberCenter() {
            string userName = Request.Cookies["userName"] ?? "Guest";
            if (userName == "Guest") {
                return Redirect("/Home/Index");
            }
            return View();
        }

        public IActionResult Logout() {
            Response.Cookies.Delete("userName");
            return Redirect("/Home/Index");
        }

    }
}
