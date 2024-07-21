using Domain;
using Domain.BusinessIRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaxCalculatorContext _context;

        public UnitOfWork(
            TaxCalculatorContext context,
            IVehicleTaxesRepository vehicleTaxesRepository,
            IVehicleRepository vehicleRepository,
            IPlateRepository plateRepository)
        {
            _context = context;
            this.vehicleTaxesRepository = vehicleTaxesRepository;
            VehicleRepository = vehicleRepository;
            PlateRepository = plateRepository;
        }


        public IVehicleTaxesRepository vehicleTaxesRepository { get; }

        public IVehicleRepository VehicleRepository { get; }

        public IPlateRepository PlateRepository { get; }

        public void Commit() => _context.SaveChanges();

        public void Rollback() => _context.Database.RollbackTransaction();// Rollback changes if needed

        public async Task RollbackAsync() => await _context.Database.RollbackTransactionAsync();

        public async Task CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

        public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

    }
}
