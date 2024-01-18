namespace VideoGameLibrary.Models
{
	public class Game
	{
		private static int nextID = 0;
		public int? Id { get; set; } = nextID++;

		public string Title { get; set; }
		public string Platform { get; set; }
		public string Genre { get; set; }
		public float Rating { get; set; }
		public int Year { get; set; }
		public string Image { get; set; }
		public DateTime? LoanedTo { get; set; }
		public DateTime? LoanDate { get; set; }

		// Always need an empty constructor
		public Game() { }

		public Game(string title, string platform, string genre, float rating, int year, string image, DateTime? loanedTo, DateTime? loanDate)
		{
			Title = title;
			Platform = platform;
			Genre = genre;
			Rating = rating;
			Year = year;
			Image = image;
			LoanedTo = loanedTo;
			LoanDate = loanDate;
		}

	}
}
