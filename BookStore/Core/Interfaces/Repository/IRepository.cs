using System.Linq.Expressions;

namespace BookStore.Core.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> expression);
        void Delete(TEntity entity);
        Task<int> SaveChanges();
    }
}
