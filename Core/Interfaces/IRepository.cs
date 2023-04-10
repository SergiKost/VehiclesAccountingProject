using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T Find(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindAll(Func<IQueryable<T>, IQueryable<T>> func);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T,bool>> predicate);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<int> DeleteAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities);
    }
}
