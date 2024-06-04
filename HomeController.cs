using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApplication.Models;

namespace SimpleWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(string Name, string Email, string Phone, string CompanyName)
        {
            ViewData["Message"] = $"Welcome, {Name}!";
            return View("Index");
        }
    }
}
