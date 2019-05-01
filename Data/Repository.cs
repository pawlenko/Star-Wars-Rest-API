
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SW.Data;
using SW.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SW.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _repositoryContext { get; set; }

        public Repository(ApplicationDbContext repositoryContext)
        {
          _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> dbQuery = _repositoryContext.Set<T>();

            if (includes != null)
                dbQuery = includes(dbQuery);



            return await dbQuery.AsNoTracking().ToListAsync();
            
        }


        public async Task<IEnumerable<T>> GetRangeAsync(int index, int count, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {

            IQueryable<T> dbQuery = _repositoryContext.Set<T>();

            if (includes != null)
                dbQuery = includes(dbQuery);



            return await dbQuery.AsNoTracking().Skip((index - 1) * count).Take(count).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindRangeAsync(int index, int count, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {

            IQueryable<T> dbQuery = _repositoryContext.Set<T>();

            if (includes != null)
                dbQuery = includes(dbQuery);


            return await dbQuery.AsNoTracking().Where(expression).Skip((index - 1) * count).Take(count).ToListAsync();
        }


        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> dbQuery = _repositoryContext.Set<T>();

            if (includes != null)
                dbQuery = includes(dbQuery);

            return await dbQuery.AsNoTracking().Where(expression).ToListAsync();
        }



        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> dbQuery = _repositoryContext.Set<T>();

            if (includes != null)
                dbQuery = includes(dbQuery);

            return await dbQuery.AsNoTracking().SingleOrDefaultAsync(match);
        }

        public async Task<int> CountAsync()
        {
            return await _repositoryContext.Set<T>().CountAsync();
        }


        public async  Task<T> CreateAsync(T entity)
        {
             _repositoryContext.Set<T>().Add(entity);
             await _repositoryContext.SaveChangesAsync();
             return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
             await _repositoryContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
             await _repositoryContext.SaveChangesAsync();
        }


    }
}