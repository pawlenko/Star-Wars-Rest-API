using Microsoft.EntityFrameworkCore.Query;
using SW.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SW.Repository
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IEnumerable<T>> GetRangeAsync(int index, int count, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IEnumerable<T>> FindRangeAsync(int index, int count, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<T> FindAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<int> CountAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}