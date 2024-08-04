using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Models;
using Wandermate.Models;

namespace Wandermate.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<TravelPackages> TravelPackage { get; set; }
        public DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Review)
                .WithOne(i => i.Hotel)
                .HasForeignKey(i => i.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
