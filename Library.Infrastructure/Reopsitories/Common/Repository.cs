using Library.Application.Reopsitories.Common;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Library.Infrastructure.Reopsitories.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _Context;
        private DbSet<T> _Set;
        public Repository(AppDbContext Context)
        {
            _Context = Context;
            _Set = _Context.Set<T>();
        }   


        public void Add(T entity)
        {
            _Set.Add(entity);   
        }

        public void AddRange(List<T> entities)
        {
            _Set.AddRange(entities);
        }

        public T? Get(Expression<Func<T, bool>> Filter, string[]? includeProperties = null)
        {

            IQueryable<T> Query = _Set;

            Query = Query.Where(Filter);

            if (includeProperties is not null && includeProperties.Count() > 0)
            {
                foreach (string property in includeProperties)
                {
                    Query = Query.Include(property);
                }
            }
            return Query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter, string[]? includeProperties = null)
        {
            IQueryable<T> Query = _Set;

            if (Filter is not null)
                Query = Query.Where(Filter);

            if (includeProperties is not null && includeProperties.Count() > 0)
            {
                foreach(string property in includeProperties)
                {
                    Query = Query.Include(property);
                }
            }

            return Query.ToList();
        }

        public bool IsExist(Expression<Func<T, bool>> Filter)
        {
            return _Set.Any(Filter);
        }

        public virtual void Remove(T entity)
        {
            _Set.Remove(entity);
        }
    }
}
