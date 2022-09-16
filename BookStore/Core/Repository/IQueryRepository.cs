using System.Linq.Expressions;

namespace BookStore.Core.Repository
{
    public interface IQueryRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> expression);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> OrderBy(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Skip(int skip);
        IQueryable<TEntity> Take(int count);
    }
}
