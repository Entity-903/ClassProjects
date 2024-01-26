using Movies.Models;

namespace MoviesDal.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<Movie> GetMovies();
		void AddMovie(Movie movie);
		void RemoveMovie(int id);
		Movie? GetMovie(int id);
		void UpdateMovie(Movie movie);
	}
}
