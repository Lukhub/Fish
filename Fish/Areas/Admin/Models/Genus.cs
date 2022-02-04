using System;
using System.ComponentModel.DataAnnotations;

namespace Fish.Models
{
	public class Genus
	{
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }

		public int FamilyId { get; set; }
        public Family? Family { get; set; }

		public List<Animal>? Animals { get; set; }

    }
}

