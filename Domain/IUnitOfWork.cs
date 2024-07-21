using Domain.BusinessIRepositories;

namespace Domain
{
    public interface IUnitOfWork:IDisposable
    {

        public IVehicleTaxesRepository vehicleTaxesRepository { get; }
        public IVehicleRepository VehicleRepository { get; }
        public IPlateRepository PlateRepository { get; }
       
        void Commit();

        public Task CommitAsync();

        void Rollback();

        public Task RollbackAsync();

        public Task BeginTransactionAsync();

    }
}
