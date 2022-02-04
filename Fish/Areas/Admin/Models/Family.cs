using System;
using System.ComponentModel.DataAnnotations;

namespace Fish.Models
{
	public class Family
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = String.Empty;

		public List<Genus>? genera { get; set; }
	}
}

