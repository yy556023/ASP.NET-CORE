using Lab_MultiUsers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_MultiUsers.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        private LabDbContext _context;

        public HomeController(ILogger<HomeController> logger, LabDbContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {
            var t = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            Product obj = _context.Products.Find(2);
            t.Commit();
            return View(obj);
        }

        [HttpPost]
        public IActionResult Buy() {
            var t = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            Product obj = _context.Products.FromSqlRaw<Product>("select * from products with (xlock) where productId = 2").FirstOrDefault();
            obj.UnitsInStock -= 1;
            _context.SaveChanges();
            System.Threading.Thread.Sleep(1000 * 10);
            t.Commit();
            return View(obj.UnitsInStock);
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
