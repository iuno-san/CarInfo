using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Infrastructure.Persistence
{
    public class CarInfoDbContext : IdentityDbContext
    {
        public CarInfoDbContext(DbContextOptions<CarInfoDbContext> options) : base(options)
        {
            
        }

        public DbSet<Domain.Entities.CarInfo> CarsInfos { get; set; }

        public DbSet<Domain.Entities.Vehicle> Vehicles { get; set; }

        public DbSet<Domain.Entities.CarModels> CarModels { get; set; }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.CarInfo>()
                .OwnsOne(c => c.ContactDetails);
        }
    }
}
