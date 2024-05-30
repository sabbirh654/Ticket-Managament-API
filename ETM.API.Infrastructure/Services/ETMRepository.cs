using ETM.API.Core.Exceptions;
using ETM.API.Infrastructure.Interfaces;
using ETM.API.Repository.Context;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace ETM.API.Infrastructure.Services
{
    public class ETMRepository<T> : IETMRepository<T> where T : class
    {
        private DataContext _dbContext;

        private DbSet<T> _dbSet;

        public ETMRepository(DataContext context)
        {
            _dbContext = context;

            _dbSet = context.Set<T>();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in ETMRepository : AddAsync(T entity) method", ex);
            }
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in ETMRepository : GetByIdAsync(object id) method", ex);
            }
        }


        public virtual async Task<List<T>> FilterByAsync(List<Expression<Func<T, bool>>> searchBy, int pageNumber, int pageSize, bool isAscendingOrder, Expression<Func<T, DateTime>>? sortCondition, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> result = _dbSet;

                foreach (var condition in searchBy)
                {
                    result = result.Where(condition);
                }

                foreach (var includeExpression in includes)
                    result = result.Include(includeExpression);

                if (sortCondition != null)
                {
                    result = isAscendingOrder ? result.OrderBy(sortCondition) : result.OrderByDescending(sortCondition);
                }

                result = result.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in ETMRepository : FilterByAsync() method", ex);
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in ETMRepository : UpdateAsync(T entity) method", ex);
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in ETMRepository : DeleteAsync(T entity) method", ex);
            }
        }

        public virtual async Task<T> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            var result = _dbSet.Where(predicate);

            return await result.FirstOrDefaultAsync();
        }

    }
}
