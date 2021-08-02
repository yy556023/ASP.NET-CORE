using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Controller.Models;

namespace Lab_Controller.Controllers
{
    public class LabController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // https://localhost:port/Lab/TestText
        public ActionResult TestText()
        {
            return Content("Hello! World.");
        }

        // https://localhost:port/Lab/About
        // https://localhost:port/Lab/AboutMe
        [ActionName("AboutMe")]
        public ActionResult About()
        {
            return Content("About");
        }

        // https://localhost:port/Lab/TestXML
        public ActionResult TestXML()
        {
            //ContentResult result = new ContentResult();
            //result.Content = "<book><title>bookName</title><price>500</price></book>";
            //result.ContentType = "text/xml";
            ContentResult result = new ContentResult
            {
                Content = "<book><title>bookName</title><price>500</price></book>",
                ContentType = "text/xml"
            };

            return result;
        }

        // https://localhost:port/Lab/TestRedirect
        public ActionResult TestRedirect()
        {
            return Redirect("http://www.hinet.net");
            //return RedirectToAction("Privacy", "Home");
        }


        // https://localhost:port/Lab/TestQueryString?FirstName=Jeremy&LastName=Lin
        public ActionResult TestQueryString()
        {
            string result = string.Format(
                "FirstName = {0} <br> LastName = {1}",
                HttpContext.Request.Query["FirstName"],
                HttpContext.Request.Query["LastName"]
                );
            return Content(result, "text/html");
        }

        // https://localhost:port/Lab/TestInput?FirstName=Jeremy&LastName=Lin
        public ActionResult TestInput(string LastName, string FirstName)
        {
            string result = string.Format(
                "FirstName => {0} <br> LastName => {1}",
                FirstName,
                LastName
                );
            return Content(result, "text/html");
        }

        // copy test.html into wwwroot folder
        // https://localhost:port/test.html
        //public ActionResult TestForm(IFormCollection frm) {
        //    string result = string.Format(
        //        "FirstName :: {0} <br> LastName :: {1}",
        //        frm["FirstName"],
        //        frm["LastName"]
        //        );
        //    return Content(result, "text/html");
        //}

        // create a class named Employee in Models folder
        // using Lab_Controller.Models;
        // https://localhost:port/test.html
        public ActionResult TestForm(Employee emp)
        {
            string result = string.Format(
                "FirstName ::> {0} <br> LastName ::> {1}",
                emp.FirstName,
                emp.LastName
                );
            return Content(result, "text/html");
        }

        // https://localhost:port/Lab/TestID/3
        public ActionResult TestID(string id)
        {
            return Content("ID: " + id);
        }

    }
}
