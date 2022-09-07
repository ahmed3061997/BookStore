using BookStore.Core.Domain;
using BookStore.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Core.Implementations.Repositiory
{
    public class DbRepo<TEntity> : IQueryRepository<TEntity> where TEntity : class
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

        public async void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await Get(expression);
            if (entity == null)
            {
                throw new NullReferenceException("No such entity found");
            }
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression);
        }
    }
}
