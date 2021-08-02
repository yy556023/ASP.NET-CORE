using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_MVC_ToDo_HandMake.Models;

namespace Lab_MVC_ToDo_HandMake.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = _context.TodoItems.ToList();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return Redirect("/Todo/Index");
        }

        public IActionResult Edit(long? id)
        {
            var todoItem = _context.TodoItems.Find(id);
            return View(todoItem);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem item)
        {
            var todoItem = _context.TodoItems.Find(item.TodoItemId);
            todoItem.Name = item.Name;
            todoItem.IsComplete = item.IsComplete;
            _context.SaveChanges();
            return Redirect("/Todo/Index");
        }

        public IActionResult Delete(long? id)
        {
            var todoItem = _context.TodoItems.Find(id);
            return View(todoItem);
        }

        [HttpPost]
        public IActionResult Delete(long TodoItemId)
        {
            var todoItem = _context.TodoItems.Find(TodoItemId);
            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();
            return Redirect("/Todo/Index");
        }
    }
}
