using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookStore.Repo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int skip, int take);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, int skip, int take);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> expression);
        void Delete(TEntity entity);
    }
}
