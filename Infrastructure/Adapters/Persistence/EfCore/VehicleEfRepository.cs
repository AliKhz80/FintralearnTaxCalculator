using Application.Ports.Driven.Persistence;
using Domain.Entities;

namespace Infrastructure.Adapters.Persistence.EfCore
{
    /// <summary>
    /// EF Core adapter for <see cref="IVehicleRepository"/>.
    /// Driven adapter: implements the output port defined in the Application Core.
    /// </summary>
    public sealed class VehicleEfRepository : EfRepository<Vehicle>, IVehicleRepository
    {
        public VehicleEfRepository(TaxCalculatorDbContext context) : base(context) { }
    }
}
