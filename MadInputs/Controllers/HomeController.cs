using System.Diagnostics;
using MadInputs.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadInputs.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Input()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Output(string FirstInput, string SecondInput, string ThirdInput, string FourthInput, string FifthInput)
		{
			ViewBag.First = FirstInput;
			ViewBag.Second = SecondInput;
			ViewBag.Third = ThirdInput;
			ViewBag.Fourth = FourthInput;
			ViewBag.Fifth = FifthInput;

			return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}