namespace Application.Ports.Driven.Persistence
{
    /// <summary>
    /// Output Port (driven port): unit-of-work contract that coordinates multiple
    /// repository operations within a single transaction.
    /// The Application Core defines this interface; the Infrastructure layer implements it.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IVehicleTaxRepository VehicleTaxRepository { get; }
        IVehicleRepository    VehicleRepository    { get; }
        IPlateRepository      PlateRepository      { get; }

        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
        Task BeginTransactionAsync();
    }
}
