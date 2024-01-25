using System.ComponentModel.DataAnnotations;
using Movies.Validators;

namespace Movies.Models
{
    [EightiesMovieRatings]
    public class Movie
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        [Required(ErrorMessage = "Movie Title is required, you dummy!")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public int? Year { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 inclusive")]
        public float? Rating { get; set; }

        [Required]
        public string Image { get; set; }

        public DateTime? ReleaseDate { get; set; }

        // Always need an empty constructor
        public Movie() { }

        public Movie(string title, int? year, float? rating, string image)
        { 
            Title = title; 
            Year = year; 
            Rating = rating;
            Image = image;
        }
    }


}
