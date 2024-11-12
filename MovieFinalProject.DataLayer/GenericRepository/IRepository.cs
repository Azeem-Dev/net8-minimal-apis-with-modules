using MovieFinalProject.Shared.DbOptions;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieFinalProject.DataLayer.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync(FindOptions? findOptions = null);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null);
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null);
        Task AddAsync(TEntity entity);
        Task AddManyAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
