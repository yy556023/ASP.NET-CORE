using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpContext _context;

        public EmployeeController(EmpContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = _context.employee.ToList();
            return View(viewModel);
        }

        public IActionResult Detail(int? id)
        {
            Employee item = _context.employee.Find(id);
            return View(item);
        }

        public IActionResult Update(int? id)
        {
            Employee item = _context.employee.Find(id);
            return View(item);
        }
    }
}
