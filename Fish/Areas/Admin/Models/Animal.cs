using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fish.Models
{
	public enum CareLevel
	{
		Easy = 0,
		moderate = 1,
		Difficult = 2,
		Expert_Only = 3
	}

	public enum Temparament
	{
		Peaceful = 0,
		Semi_aggressive = 1,
		Aggressive = 2
	}

	public class Animal
	{
		public int ID { get; set; }
		[Required]
		public string? Name { get; set; }

		[Required]
		public CareLevel CareLevel { get; set; }

		[Required]
		public Temparament Temparament { get; set; }

		[Required]
		public int MaxSize { get; set; }

		[NotMapped]
		public IFormFile? Image { get; set; }

		public string? Photo { get; set; }

		public int GenusID { get; set; }
		public Genus? Genus { get; set; }
		
	}
}

