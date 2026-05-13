using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Persistence.EfCore
{
    /// <summary>
    /// EF Core DbContext adapter.
    ///
    /// Hexagonal role: this is an INFRASTRUCTURE concern — a driven adapter that
    /// provides the SQL Server persistence mechanism. It must NOT leak into the
    /// Domain or Application layers.
    /// </summary>
    public sealed class TaxCalculatorDbContext : DbContext
    {
        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options)
            : base(options) { }

        public DbSet<Vehicle>    Vehicles    { get; set; } = null!;
        public DbSet<Plate>      Plates      { get; set; } = null!;
        public DbSet<VehicleTax> VehicleTaxes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(v => v.Name).HasMaxLength(50).IsRequired();
                entity.Property(v => v.Color).HasMaxLength(20).IsRequired();
            });

            modelBuilder.Entity<Plate>(entity =>
            {
                entity.Property(p => p.PlateNumber).HasMaxLength(7).IsRequired();
            });
        }
    }
}
