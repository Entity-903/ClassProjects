namespace Movies.Models
{
    public class Movie
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        public string Title { get; set; }
        public int? Year { get; set; }
        public float? Rating { get; set; }

        // Always need an empty constructor
        public Movie() { }

        public Movie(string title, int? year, float? rating)
        { 
            Title = title; 
            Year = year; 
            Rating = rating; 
        }
    }


}
