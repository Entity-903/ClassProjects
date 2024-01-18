using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> MovieList = new List<Movie>
    {
        new Movie("A Series of Unfortunate Events", 2004, 4.0f, ""),
        new Movie("Everything Everywhere All At Once", 2022, 4.5f, ""),
        new Movie("Spider-Man Across the Spider-Verse", 2023, 5f, "/images/AcrossTheSpiderVerse.jpg")
    };

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
