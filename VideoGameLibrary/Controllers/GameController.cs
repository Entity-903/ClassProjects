using Microsoft.AspNetCore.Mvc;

namespace VideoGameLibrary.Controllers
{
    public class GameController : Controller
    {

        private static List<Game> MovieList = new List<Game>
    {
        new Game("A Series of Unfortunate Events", 2004, 4.0f, ""),
        new Game("Everything Everywhere All At Once", 2022, 4.5f, ""),
        new Game("Spider-Man Across the Spider-Verse", 2023, 5f, "/images/AcrossTheSpiderVerse.jpg")
    };

        public IActionResult Collection()
        {
            return View();
        }

        public IActionResult Loan()
        {
            return View();
        }
    }
}
