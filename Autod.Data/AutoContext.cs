using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autod.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Autod.Data
{
    public class AutoContext : DbContext
    {
        public AutoContext
            (
                    DbContextOptions<AutoContext> options
            ) : base(options) { }



        public DbSet<LandingPage> LandingPages { get; set; }
        public DbSet<CarService> CarServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarService>()
                .HasOne(cs => cs.Customer)
                .WithMany(c => c.CarService)
                .HasForeignKey(cs => cs.CustomerId);
        }

    }
}
