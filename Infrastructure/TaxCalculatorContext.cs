using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TaxCalculatorContext : DbContext
    {
        public TaxCalculatorContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<VehicleTax> VehicleTaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("name=TaxCalculator");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }

  

    

}
