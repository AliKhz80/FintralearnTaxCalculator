using Application.Ports.Driven.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Persistence.EfCore
{
    /// <summary>
    /// EF Core adapter for <see cref="IVehicleTaxRepository"/>.
    /// Driven adapter: implements the output port defined in the Application Core.
    /// </summary>
    public sealed class VehicleTaxEfRepository : EfRepository<VehicleTax>, IVehicleTaxRepository
    {
        private readonly TaxCalculatorDbContext _context;

        public VehicleTaxEfRepository(TaxCalculatorDbContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<bool> CheckVehicleTaxFullPaymentPerCurrentDay(string plateNumber)
        {
            var startOfDay = DateTime.Now.Date;
            var endOfDay   = startOfDay.AddDays(1);

            int totalTaxPaidToday = await _context.VehicleTaxes
                .Where(vt => vt.Plate.PlateNumber == plateNumber
                          && vt.TaxPaidDate >= startOfDay
                          && vt.TaxPaidDate <  endOfDay)
                .SumAsync(vt => vt.Tax);

            // Daily cap is 60 SEK.
            return totalTaxPaidToday >= 60;
        }
    }
}
