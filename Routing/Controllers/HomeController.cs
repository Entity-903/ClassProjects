using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
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
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult DefaultCow(int id)
		{
			return Content("The cow Default Cow moos at you " + id + " times.");
		}

		public IActionResult EatLessYouCow()
		{
			return Redirect("https://www.chick-fil-a.com/");
		}

		public IActionResult TheCowInQuestion(int id, string name)
		{
			return Content("The cow " + name + " moos at you " + id + " times.");
		}

		public IActionResult CowConvention(int id)
		{
			return Content("There are " + id + " cows on page.");
		}

		public IActionResult CowConventionDoxxed(int id1, int id2)
		{
			return Content("There are " + id1 + " cows per page, on page " + id2 + ".");
		}
		public IActionResult CowvertOperation(int id1, int id2)
		{
			return Content("There are " + id1 + " cows on page " + id2 + ".");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}