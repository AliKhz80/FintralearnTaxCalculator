using Domain.Entities;

namespace Application.Ports.Driven.Persistence
{
    /// <summary>
    /// Output Port (driven port): specific persistence contract for <see cref="VehicleTax"/>.
    /// Extends the generic repository with domain-specific query operations.
    /// </summary>
    public interface IVehicleTaxRepository : IRepository<VehicleTax>
    {
        /// <summary>
        /// Returns <c>true</c> if the total tax already paid for <paramref name="plateNumber"/>
        /// today equals or exceeds the daily maximum (60 SEK).
        /// </summary>
        Task<bool> CheckVehicleTaxFullPaymentPerCurrentDay(string plateNumber);
    }
}
