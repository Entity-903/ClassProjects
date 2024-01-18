using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private static int intCount = 0;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult ParamTest(int? id, string s)
		{
            //return Content("Stuff"); // Content just returns simple text
            return Content($"id = {id?.ToString() ?? "NULL"} {s}");
            //id? = Nullable Variable
            // ?? = Null coalescing operator, if variable is not null, do left; if null, do right;
		}

		public IActionResult Privacy(string id)
        {
            return View();
        }

        public IActionResult Counter()
        {
            ViewBag.Count = intCount++;
            ViewData["Count"] = intCount;

            return View();
        }

        [HttpGet]
        public IActionResult Input()
        {
            ViewData["Title"] = "Input Form";

            return View();
        }

        [HttpPost]
        public IActionResult Output(string FirstName, string LastName)
		{
            ViewBag.FN = FirstName;
            ViewBag.LN = LastName;

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AlternateViews()
        {
            return View();
        }
    }
}