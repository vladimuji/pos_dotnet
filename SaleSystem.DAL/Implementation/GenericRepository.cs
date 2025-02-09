using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleSystem.DAL.DBContext;
using SaleSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SaleSystem.DAL.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly Dbsale0014Context _dbContext;
        public GenericRepository(Dbsale0014Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> Read(Expression<Func<TEntity, bool>> filter)
        {
            //throw new NotImplementedException();
            try
            {
                TEntity entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(filter);
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            //throw new NotImplementedException();
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            //throw new NotImplementedException();
            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            //throw new NotImplementedException();
            try
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> Check(Expression<Func<TEntity, bool>> filter = null)
        {
            //throw new NotImplementedException();
            IQueryable<TEntity> queryEntity = filter == null ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().Where(filter);
            return queryEntity;
        }

    }
}
