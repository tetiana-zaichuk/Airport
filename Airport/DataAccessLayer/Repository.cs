using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataSeends Context;

        public Repository(DataSeends context)
        {
            Context = context;
        }

        public virtual List<TEntity> Get(int? filter = null)
        {
            List<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(e => e.Id == filter).ToList();
            }

            return query.ToList();
        }

        public virtual void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var index = Context.Set<TEntity>().FindIndex(e => e.Id == entity.Id);
            Context.Set<TEntity>()[index] = entity;
        }

        public virtual void Delete(int? filter = null)
        {
            List<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                Delete(query.Find(e => e.Id == filter));
            }
            else
            {
                query.Clear();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
