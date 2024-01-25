﻿using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
	public class GameController : Controller
	{

		private static List<Game> GameList = new List<Game>
	{
		new Game("Deep Rock Galactic", "PC", "FPS", "T", 2020, "/images/DRG.jpg"),
		new Game("Team Fortress 2", "PC", "FPS", "M", 2007, "/images/TF2.jpg"),
		new Game("Ori and the Blind Forest", "PC", "Metroidvania", "E", 2015, "/images/BlindForest.jpg"),
		new Game("Ori and the Will of the Wisps", "PC", "Metroidvania", "E", 2020, "/images/WillOfTheWisps.jpg"),
		new Game("Lethal Company", "PC", "Horror", "Not Rated", 2023, "/images/LethalCompany.jpg")
	};

		[HttpGet]
		public IActionResult Collection()
		{
			return View(GameList);
		}

		[HttpPost]
		public IActionResult Collection(string? LoanedTo, int id)
		{
			Game g = GameList.Find(x => x.Id == id);

			if (string.IsNullOrEmpty(LoanedTo))
			{
				g.LoanDate = null;
			}
			else
			{
				g.LoanedTo = LoanedTo;
				g.LoanDate = DateTime.Now;
			}

			return View(GameList);
		}

		public IActionResult Loan()
		{
			return View();
		}
	}
}
