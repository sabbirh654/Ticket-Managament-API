using System.Linq.Expressions;

namespace ETM.API.Infrastructure.Interfaces
{
    public interface IETMRepository<T>
    {
        Task<bool> AddAsync(T entity);
        Task<List<T>> FilterByAsync(List<Expression<Func<T, bool>>> searchBy, int pageNumber, int pageSize, bool isAscendingOrder, Expression<Func<T, DateTime>> sortCondition, params Expression<Func<T, object>>[] includes);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetByIdAsync(object id);
        Task<T> FindByAsync(Expression<Func<T, bool>> predicate);
    }
}
