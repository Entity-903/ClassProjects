using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult ValidateForm()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ValidateForm(UserInfo userInfo)
		{


			if ((userInfo.Street == null && userInfo.City == null && userInfo.State == null && userInfo.ZipCode == null) ||
				(userInfo.Street != null && userInfo.City != null && userInfo.State != null && userInfo.ZipCode != null))
			{
				if (ModelState.IsValid)
				{
					return RedirectToAction("Success", "Home");
				}
			}
			else
			{
				ModelState.AddModelError("Street", "Address cannot be incomplete!");
			}
			return View();
		}

		public IActionResult Success()
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