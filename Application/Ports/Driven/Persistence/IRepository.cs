namespace Application.Ports.Driven.Persistence
{
    /// <summary>
    /// Output Port (driven port): generic repository contract that all persistence
    /// adapters must implement. The Application Core defines this interface; the
    /// Infrastructure layer provides the concrete EF Core implementation.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllQueryable();
        Task<TEntity?> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        void UpdateAllFields(TEntity entity);
        void UpdateChangedFields(TEntity entity);
        void Delete(TEntity entity);
    }
}
