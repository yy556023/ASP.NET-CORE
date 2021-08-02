using Lab_Login_Session.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lab_Login_Session.Controllers {
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

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password) {
            if (string.IsNullOrEmpty(userName)) {
                return View();
            }
            HttpContext.Session.SetString("userName", userName);
            return Redirect("/Home/Index");
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("userName");
            return Redirect("/Home/Index");
        }

        public IActionResult MemberCenter() {
            string userName = HttpContext.Session.GetString("userName") ?? "Guest";
            if (userName == "Guest") {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
