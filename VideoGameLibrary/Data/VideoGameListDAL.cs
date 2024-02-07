using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Data
{
	public class VideoGameListDAL : IDataAccessLayer
	{
			private static List<Game> GameList = new List<Game>
		{
			new Game("Deep Rock Galactic", "PC", "FPS", "T", 2020, "/images/DRG.jpg"),
			new Game("Team Fortress 2", "PC", "FPS", "M", 2007, "/images/TF2.jpg"),
			new Game("Ori and the Blind Forest", "PC", "Metroidvania", "E", 2015, "/images/BlindForest.jpg"),
			new Game("Ori and the Will of the Wisps", "PC", "Metroidvania", "E", 2020, "/images/WillOfTheWisps.jpg"),
			new Game("Lethal Company", "PC", "Horror", "Not Rated", 2023, "/images/LethalCompany.jpg")
		};

		public void AddGame(Game game)
		{
			GameList.Add(game);
		}

		public Game? GetGame(int id)
		{
			Game? foundGame = GameList.Where(m => m.Id == id).FirstOrDefault();
			return foundGame;
		}

		public IEnumerable<Game> GetGames()
		{
			return GameList;
		}

		public void RemoveGame(int id)
		{
			Game? foundGame = GetGame(id);
			if (foundGame != null) GameList.Remove(foundGame);
		}

		public void UpdateGame(Game game)
		{
			int i = GameList.FindIndex(x => x.Id == game.Id);
			GameList[i] = game;

		}
	}
}
