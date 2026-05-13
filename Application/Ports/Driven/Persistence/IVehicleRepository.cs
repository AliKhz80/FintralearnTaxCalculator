using Domain.Entities;

namespace Application.Ports.Driven.Persistence
{
    /// <summary>
    /// Output Port (driven port): persistence contract for <see cref="Vehicle"/> entities.
    /// </summary>
    public interface IVehicleRepository : IRepository<Vehicle>
    {
    }
}
