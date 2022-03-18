using System.Linq.Expressions;

namespace BackEnd.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(object id);

        Task<T> GetByAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);


        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task DeleteAsync(object id);

        Task SoftDeleteAsync(object id);
    }
}