using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly VehicleDbContext _context;

        public GenericRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll() => _context.Set<T>().AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public T Find(Expression<Func<T, bool>> expression) => _context.Set<T>().SingleOrDefault(expression);

        public async Task<T> FindAsync(Expression<Func<T,bool>> expression) => await _context.Set<T>().SingleOrDefaultAsync(expression);

        public IQueryable<T> FindAll(Func<IQueryable<T>, IQueryable<T>> func) => func(_context.Set<T>().AsNoTracking());

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T,bool>> expression) => await _context.Set<T>().Where(expression).ToListAsync();

        public async Task<T> AddAsync(T entity)
        {

             _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if(entity == null) {  return null; }

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entityList)
        {
            _context.Set<T>().AddRange(entityList);
            await _context.SaveChangesAsync();
            return entityList;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entityList)
        {
            _context.Set<T>().UpdateRange(entityList);
            await _context.SaveChangesAsync();
            return entityList;
        }

        public async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entityList) 
        {
            _context.Set<T>().RemoveRange(entityList);
            await _context.SaveChangesAsync();
            return entityList;
        }


    }
}
