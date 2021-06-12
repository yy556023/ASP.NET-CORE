using Lab_DI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab_DI.Services;

namespace Lab_DI.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        private IDateTime _dateTime;

        public HomeController(ILogger<HomeController> logger, IDateTime dateTime) {
            _logger = logger;
            _dateTime = dateTime;
        }

        public IActionResult Index() {
            ViewData["now"] = _dateTime.Now;
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
