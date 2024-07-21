using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _Dbcontext;
        private DbSet<TEntity> dbset;

        public Repository(DbContext DbContext)
        {
            _Dbcontext = DbContext;
            dbset = DbContext.Set<TEntity>();
        }

        public virtual  async Task<List<TEntity>> GetAllAsync()
        {
            return await dbset.AsNoTracking().ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAllQueryable()
        {
            return dbset.AsNoTracking().AsQueryable();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await dbset.FindAsync(id);
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await dbset.AddAsync(entity);
        }

        public virtual  void UpdateAllFields(TEntity entity)
        {
             dbset.Update(entity);
        }

        public virtual  void UpdateChangedFields(TEntity entity)
        {
             dbset.Attach(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

#if (!configureUnitOfWork)
        public async Task SaveAsync()
        {
            
            await _Dbcontext.SaveChangesAsync();
        }
#endif
    }
}