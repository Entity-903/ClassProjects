using Movies.Models;
using MoviesDal.Interfaces;

namespace MoviesDal.Data
{
	public class MovieListDAL : IDataAccessLayer
	{
		private static List<Movie> MovieList = new List<Movie>
	{
		new Movie("A Series of Unfortunate Events", 2004, 4.0f, "/images/Unfortunate.jpg"),
		new Movie("Everything Everywhere All At Once", 2022, 4.5f, "/images/EverythingEverywhere.jpg"),
		new Movie("Spider-Man 2", 2004, 5.0f, "/images/Spider-Man_2.jpg"),
		new Movie("Spider-Man Across the Spider-Verse", 2023, 5f, "/images/AcrossTheSpiderVerse.jpg")
	};

		public void AddMovie(Movie movie)
		{
			MovieList.Add(movie);
		}

		public Movie? GetMovie(int id)
		{
			Movie? foundMovie = MovieList.Where(m => m.Id == id).FirstOrDefault();
			return foundMovie;
		}

		public IEnumerable<Movie> GetMovies()
		{
			return MovieList;
		}

		public void RemoveMovie(int id)
		{
			Movie? foundMovie = GetMovie(id);
			if (foundMovie != null)	MovieList.Remove(foundMovie);
		}

		public void UpdateMovie(Movie movie)
		{
			int i = MovieList.FindIndex(x => x.Id == movie.Id);
			MovieList[i] = movie;

		}
	}
}
