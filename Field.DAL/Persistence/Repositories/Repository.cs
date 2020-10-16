using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Field.DAL.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Set;

        public Repository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; 
        /// this method throws an exception if more than one element satisfies the condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.SingleOrDefault(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        //public void AddRange(IEnumerable<TEntity> entities)
        //{
        //    Set.AddRange(entities);
        //}

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    Set.RemoveRange(entities);
        //}

        //IQueryable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _set.Where(predicate);
        //}

        public void Attach(TEntity entity)
        {
            Set.Attach(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public T SPGet<T>(Dictionary<string, object> param) where T : class
        {
            var ctx = Context as FieldContext;

            if (ctx == null) return null;

            var response = ctx.SaveChanges();

            if ((response is T) == false) throw new ArgumentException(nameof(T) + " type is not supported");

            return response as T;
        }

        public virtual void Dispose()
        {
            //Set = null;
            GC.SuppressFinalize(this);
        }
    }
}
