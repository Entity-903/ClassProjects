using System.ComponentModel.DataAnnotations;
using Validation.Models;

namespace Validation.Models
{
	public class UserInfo
	{
		private static int nextID = 0;
		public int? Id { get; set; } = nextID++;

		[Required(ErrorMessage = "Name is required!")]
		[MaxLength(255)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Age is required!")]
		[Range(5, int.MaxValue, ErrorMessage = "Age cannot be less than 5!")]
		public int Age { get; set; }

		
		public string? Street { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public int? ZipCode { get; set; }

		// Always need an empty constructor
		public UserInfo() { }

		public UserInfo(string name, int age, string? street, string? city, string? state, int? zipCode)
		{
			Name = name;
			Age = age;
			Street = street;
			City = city;
			State = state;
			ZipCode = zipCode;
		}

	}
}
