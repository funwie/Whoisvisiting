using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Whoisvisiting.Infrastructure.Interfaces;

namespace Whoisvisiting.SqlDataAccess
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _dbContext;

        public BaseRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(InsertAsync)} entity must not be null");
            }

            try
            {
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _dbContext.Set<T>().AsNoTracking();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
            
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                var changedTrackedEntity = _dbContext.Update(entity);
                return changedTrackedEntity.Entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity != null)
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

            return entity;
        }
    }
}
