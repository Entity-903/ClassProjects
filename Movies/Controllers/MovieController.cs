using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> MovieList = new List<Movie>
    {
        new Movie("A Series of Unfortunate Events", 2004, 4.0f, "/images/Unfortunate.jpg"),
        new Movie("Everything Everywhere All At Once", 2022, 4.5f, "/images/EverythingEverywhere.jpg"),
        new Movie("Spider-Man Across the Spider-Verse", 2023, 5f, "/images/AcrossTheSpiderVerse.jpg")
    };

        public IActionResult Delete(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}
			else
			{
				int i = MovieList.FindIndex(m => m.Id == id);
				if (i == -1)
				{
                    return NotFound();
				}
                MovieList.RemoveAt(i);
				TempData["Success"] = "Movie deleted";
				return RedirectToAction("MultMovies", "Movie");
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
                Movie? m = MovieList.Where(m => m.Id == id).FirstOrDefault();
                if (m == null)
                {
                    ViewData["Error"] = "Could not find movie with this ID";
                }
                return View(m);
            }
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            int i = MovieList.FindIndex(x => x.Id == m.Id);
            if (i != -1)
            {
                MovieList[i] = m;
                TempData["Success"] = "Movie updated";
                return RedirectToAction("MultMovies", "Movie");
            }
            else
            {
				TempData["Success"] = "Update failed successfully";
				return RedirectToAction("MultMovies", "Movie");
			}
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
            MovieList.Add(m);
            return RedirectToAction("MultMovies", "Movie");
            //return View();
        }

        public IActionResult MultMovies()
		{
			return View(MovieList);
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
