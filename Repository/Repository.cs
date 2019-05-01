
using SW.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SW.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _repositoryContext { get; set; }

        public Repository(ApplicationDbContext repositoryContext)
        {
          _repositoryContext = repositoryContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _repositoryContext.Set<T>();
        }

        public T Get(long id)
        {
            return _repositoryContext.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public void Create(T entity)
        {
             _repositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _repositoryContext.SaveChanges();
        }


    }
}