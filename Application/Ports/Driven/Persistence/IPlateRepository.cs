using Domain.Entities;

namespace Application.Ports.Driven.Persistence
{
    /// <summary>
    /// Output Port (driven port): persistence contract for <see cref="Plate"/> entities.
    /// </summary>
    public interface IPlateRepository : IRepository<Plate>
    {
        /// <summary>
        /// Retrieves a plate (with its related vehicle) by plate number string.
        /// Returns <c>null</c> if not found.
        /// </summary>
        Task<Plate?> GetPlate(string plateNumber);
    }
}
