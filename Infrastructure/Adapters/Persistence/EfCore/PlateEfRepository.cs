using Application.Ports.Driven.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Persistence.EfCore
{
    /// <summary>
    /// EF Core adapter for <see cref="IPlateRepository"/>.
    /// Driven adapter: implements the output port defined in the Application Core.
    /// </summary>
    public sealed class PlateEfRepository : EfRepository<Plate>, IPlateRepository
    {
        private readonly TaxCalculatorDbContext _context;

        public PlateEfRepository(TaxCalculatorDbContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<Plate?> GetPlate(string plateNumber)
            => _context.Plates
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(p => p.PlateNumber == plateNumber);
    }
}
