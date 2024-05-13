using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<TEntity?> GetByKeyAsync(string key);

        public Task AddAsync(TEntity entity);

        public void Delete(TEntity entity);

        public Task DeleteByKeyAsync(string key);

        public void Update(TEntity entity);
    }
}
