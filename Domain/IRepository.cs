using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllQueryable();
        Task<TEntity?> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        void UpdateAllFields(TEntity entity);
        void UpdateChangedFields(TEntity entity);
        void Delete(TEntity entity);
#if (!configureUnitOfWork)
        Task SaveAsync();
    }

#endif
}
