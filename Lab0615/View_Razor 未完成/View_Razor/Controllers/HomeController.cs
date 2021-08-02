using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using View_Razor.Models;

namespace View_Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["userName"] = "Chien";
            ViewData["twoLines"] = "Line1<br>Line2";
            Student[] studentList = new Student[] {
            new Student() { Id = 2, Name = "Jeter", Score = 92 },
            new Student() { Id = 7, Name = "Jeremy", Score = 97 },
            new Student() { Id = 8, Name = "Someone", Score = 50 }
        };
            return View(studentList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
