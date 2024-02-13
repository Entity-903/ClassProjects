using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Models;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Controllers
{
	public class GameController : Controller
	{
		IDataAccessLayer dal = new VideoGameListDAL();

		[HttpGet]
		public IActionResult Collection()
		{
			return View(dal.GetGames());
		}

		[HttpPost]
		public IActionResult Collection(string? LoanedTo, int id)
		{
			Game? g = dal.GetGame(id);//Find(x => x.Id == id);

			if (string.IsNullOrEmpty(LoanedTo))
			{
				g.LoanDate = null;
			}
			else
			{
				g.LoanedTo = LoanedTo;
				g.LoanDate = DateTime.Now;
			}

			return View(dal.GetGames());
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Game g)
		{
			if (ModelState.IsValid)
			{
				dal.AddGame(g);
				return RedirectToAction("Collection", "Game");
			}
			return View();
		}

		[HttpGet] // Loading the edit page
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				ViewData["Error"] = "Game ID not found";
				return View();
			}
			else
			{
				Game? g = dal.GetGame((int)id);
				if (g == null)
				{
					ViewData["Error"] = "Could not find Game with this ID";
				}
				return View(g);
			}
		}

		[HttpPost] // Save
		public IActionResult Edit(Game m)
		{
			dal.UpdateGame(m);
			TempData["Success"] = "Game Updated!";
			return RedirectToAction("Collection", "Game");
		}

		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			else
			{
				dal.RemoveGame((int)id);

				TempData["Success"] = "Game deleted";
				return RedirectToAction("Collection", "Game");
			}
		}

		[HttpPost]
		public IActionResult Search(string? key)
		{
			if (string.IsNullOrEmpty(key)) return View("Collection", dal.GetGames());
			return View("Collection", dal.GetGames().Where(x => x.Title.ToLower().Contains(key.ToLower())));
		}
	}
}
