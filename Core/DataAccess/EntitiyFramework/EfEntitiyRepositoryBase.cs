using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntitiyRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> fiter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(fiter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> fiter = null)
        {
            using (TContext context = new TContext())
            {
                return fiter == null
                     ? context.Set<TEntity>().ToList()
                     : context.Set<TEntity>().Where(fiter).ToList();
            }
        }
    }
}
