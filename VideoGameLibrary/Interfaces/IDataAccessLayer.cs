using VideoGameLibrary.Models;

namespace VideoGameLibrary.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<Game> GetGames();
		void AddGame(Game Game);
		void RemoveGame(int id);
		Game? GetGame(int id);
		void UpdateGame(Game Game);
	}
}
