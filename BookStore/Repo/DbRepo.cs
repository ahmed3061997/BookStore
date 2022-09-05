using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Repo
{
    public class DbRepo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BookStoreDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public DbRepo(BookStoreDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var list = GetAll(expression);
            foreach (var entity in list)
            {
                Delete(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression).AsNoTrackingWithIdentityResolution().FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return dbSet.Skip(skip).Take(take).AsNoTrackingWithIdentityResolution().ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression).AsNoTrackingWithIdentityResolution().ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, int skip, int take)
        {
            return dbSet.Where(expression).Skip(skip).Take(take).AsNoTrackingWithIdentityResolution().ToList();
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
