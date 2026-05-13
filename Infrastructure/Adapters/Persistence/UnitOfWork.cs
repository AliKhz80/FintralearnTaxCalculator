using Application.Ports.Driven.Persistence;
using Infrastructure.Adapters.Persistence.EfCore;

namespace Infrastructure.Adapters.Persistence
{
    /// <summary>
    /// EF Core implementation of the <see cref="IUnitOfWork"/> output port.
    ///
    /// Hexagonal role: driven adapter that wraps a single <see cref="TaxCalculatorDbContext"/>
    /// transaction, exposing the three repository ports to the Application Core.
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TaxCalculatorDbContext _context;

        public UnitOfWork(
            TaxCalculatorDbContext    context,
            IVehicleTaxRepository     vehicleTaxRepository,
            IVehicleRepository        vehicleRepository,
            IPlateRepository          plateRepository)
        {
            _context              = context;
            VehicleTaxRepository  = vehicleTaxRepository;
            VehicleRepository     = vehicleRepository;
            PlateRepository       = plateRepository;
        }

        public IVehicleTaxRepository VehicleTaxRepository { get; }
        public IVehicleRepository    VehicleRepository    { get; }
        public IPlateRepository      PlateRepository      { get; }

        public void Commit()         => _context.SaveChanges();
        public Task CommitAsync()    => _context.SaveChangesAsync();
        public void Rollback()       => _context.Database.RollbackTransaction();
        public Task RollbackAsync()  => _context.Database.RollbackTransactionAsync();
        public Task BeginTransactionAsync() => _context.Database.BeginTransactionAsync();
        public void Dispose()        => _context.Dispose();
    }
}
