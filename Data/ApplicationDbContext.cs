using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Models;


namespace Wandermate.Data
{

    public class ApplicationDbContext : DbContext

    {
        // internal readonly object TravelPackages;

        public ApplicationDbContext(DbContextOptions dbContextOptions)

        : base(dbContextOptions)

        {



        }




        public DbSet<Hotel> Hotel { get; set; }
        public DbSet <TravelPackages> TravelPackage { get; set; }
    }

}