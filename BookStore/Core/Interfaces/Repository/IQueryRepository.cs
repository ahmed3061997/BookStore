using System.Linq.Expressions;

namespace BookStore.Core.Interfaces.Repository
{
    public interface IQueryRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
    }
}
