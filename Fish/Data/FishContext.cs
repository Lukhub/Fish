#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fish.Models;

    public class FishContext : DbContext
    {
        public FishContext (DbContextOptions<FishContext> options)
            : base(options)
        {
        }

        public DbSet<Fish.Models.Family> Family { get; set; }

        public DbSet<Fish.Models.Genus> Genus { get; set; }

        public DbSet<Fish.Models.Animal> Animal { get; set; }
}
