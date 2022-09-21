using backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;

        public async void Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAsync()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public Task<T> GetById(Expression<Func<T, bool>> predicates)
        {
            return _context.Set<T>().SingleOrDefaultAsync(predicates);
        }

        public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
