using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Core
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
      where T : class, IEntity
    {
        protected DbContext _dbContext;

        public GenericRepository(DbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            var newEntity = await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return newEntity.Entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Can not found Id:" + id);

            _dbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            var oldEntity = await GetByIdAsync(id);
            if (oldEntity == null)
                throw new Exception("Can not found Id:" + id);

            _dbContext.Set<T>().Attach(entity);
            _dbContext.Set<T>().Update(entity);
        }
    }
}