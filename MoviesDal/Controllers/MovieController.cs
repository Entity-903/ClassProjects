using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using MoviesDal.Data;
using MoviesDal.Interfaces;

namespace Movies.Controllers
{
	public class MovieController : Controller
	{
		IDataAccessLayer dal = new MovieListDAL();

		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			else
			{
				//	int i = MovieList.FindIndex(m => m.Id == id);
				//	if (i == -1)
				//	{
				//		return NotFound();
				//	}
				//	MovieList.RemoveAt(i);
				dal.RemoveMovie((int)id);
				
				TempData["Success"] = "Movie deleted";
				return RedirectToAction("MultMovies", "Movie");
				//return View("MultMovies", dal.GetMovies());
			}
		}

		[HttpGet] // Loading the edit page
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				ViewData["Error"] = "Movie ID not found";
				return View();
			}
			else
			{
				Movie? m = dal.GetMovie((int)id);
				if (m == null)
				{
					ViewData["Error"] = "Could not find movie with this ID";
				}
				return View(m);
			}
		}

		[HttpPost] // Save
		public IActionResult Edit(Movie m)
		{
			//int i = MovieList.FindIndex(x => x.Id == m.Id);
			//if (i != -1)
			//{
			//MovieList[i] = m;
			//TempData["Success"] = "Movie updated";
			//return RedirectToAction("MultMovies", "Movie");
			//}
			//else
			//{
				dal.UpdateMovie(m);
				TempData["Success"] = "Update failed successfully";
				return RedirectToAction("MultMovies", "Movie");
			//}
		}

		[HttpGet]
		public IActionResult Add()
		{
			//Movie m = new Movie("Shrek 2", 2004, 5, "/images/Shrek2.jpg");
			//return View(m);
			return View();
		}

		[HttpPost]
		public IActionResult Add(Movie m)
		{
			// Custom Validation
			if (m.Title == "Cats")
			{
				ModelState.AddModelError("Title", "That's not a movie, it's a piece of sh*t!");
			}
			if (ModelState.IsValid)
			{
				dal.AddMovie(m);
				return RedirectToAction("MultMovies", "Movie");
				//return View();
			}
			return View();
		}

		public IActionResult MultMovies()
		{
			return View(dal.GetMovies());
		}

		//public IActionResult LoanMovie(int ID)
		//{
		//	var oneMovie = MovieList.Find(x => x.Id == ID);
		//	oneMovie ReleaseDate = DateTime.Now; // DateTime.Now = current date

		//	//return Redirect("/Movies/MultMovies");
		// return View("MultMovies");
		//}

		public IActionResult DisplayMovie()
		{
			Movie m = new Movie("Tron", 1982, 4.7f, "");
			return View(m);
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
