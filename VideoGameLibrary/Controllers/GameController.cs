using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class GameController : Controller
    {

        private static List<Game> MovieList = new List<Game>
    {
        new Game("Deep Rock Galactic", "PC", "FPS", "T", 2020, "DRG.jpg"),
        new Game("Team Fortress 2", "PC", "FPS", "M", 2007, "TF2.jpg"),
        new Game("Ori and the Blind Forest", "PC", "Metroidvania", "E", 2015, "BlindForest.avif")//,
        //new Game("Ori and the Will of the Wisps"),
        //new Game("Lethal Company")
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
