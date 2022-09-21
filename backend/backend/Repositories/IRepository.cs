using System.Linq.Expressions;

namespace backend.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAsync();
        Task<T> GetById(Expression<Func<T, bool>> predicates);
        void Add(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);

    }
}
