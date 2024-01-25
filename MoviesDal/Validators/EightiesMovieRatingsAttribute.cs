using System.ComponentModel.DataAnnotations;
using Movies.Models;

namespace Movies.Validators
{
	// Custom Validation across fields or models
	// Must end with "attribute"
	public class EightiesMovieRatingsAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var movie = (Movie)validationContext.ObjectInstance;

			if (movie.Year >= 1980 && movie.Year < 1990 && movie.Rating < 2.5)
			{
				return new ValidationResult("Movies cannot be bad in the 80s");
			}

			return ValidationResult.Success;
		}
	}
}
