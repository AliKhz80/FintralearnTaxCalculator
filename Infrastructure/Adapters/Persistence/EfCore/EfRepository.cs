using Application.Ports.Driven.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Persistence.EfCore
{
    /// <summary>
    /// Generic EF Core repository adapter implementing <see cref="IRepository{TEntity}"/>.
    ///
    /// Hexagonal role: this is a DRIVEN ADAPTER — it adapts the EF Core API to the
    /// <see cref="IRepository{TEntity}"/> output port defined in the Application Core.
    /// </summary>
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext  _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(DbContext context)
        {
            _context = context;
            _dbSet   = context.Set<TEntity>();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
            => _dbSet.AsNoTracking().ToListAsync();

        public virtual IQueryable<TEntity> GetAllQueryable()
            => _dbSet.AsNoTracking().AsQueryable();

        public virtual Task<TEntity?> GetByIdAsync(int id)
            => _dbSet.FindAsync(id).AsTask()!;

        public virtual async Task CreateAsync(TEntity entity)
            => await _dbSet.AddAsync(entity);

        public virtual void UpdateAllFields(TEntity entity)
            => _dbSet.Update(entity);

        public virtual void UpdateChangedFields(TEntity entity)
            => _dbSet.Attach(entity);

        public virtual void Delete(TEntity entity)
            => _dbSet.Remove(entity);
    }
}
