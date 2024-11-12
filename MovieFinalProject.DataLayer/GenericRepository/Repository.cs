using Microsoft.EntityFrameworkCore;
using MovieFinalProject.Shared.DbOptions;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieFinalProject.DataLayer.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _appDBContext;

        public Repository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _appDBContext.Set<TEntity>().AddAsync(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task AddManyAsync(IEnumerable<TEntity> entities)
        {
            await _appDBContext.Set<TEntity>().AddRangeAsync(entities);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _appDBContext.Set<TEntity>().Remove(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await FindAsync(predicate);
            _appDBContext.Set<TEntity>().RemoveRange(entities);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return await (await GetAsync(findOptions)).FirstOrDefaultAsync(predicate);
        }

        public async Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return (await GetAsync(findOptions)).Where(predicate);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(FindOptions? findOptions = null)
        {
            return await GetAsync(findOptions);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _appDBContext.Set<TEntity>().Update(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _appDBContext.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _appDBContext.Set<TEntity>().CountAsync(predicate);
        }

        private async Task<IQueryable<TEntity>> GetAsync(FindOptions? findOptions = null)
        {
            findOptions ??= new FindOptions();
            var entity = _appDBContext.Set<TEntity>();

            IQueryable<TEntity> query = entity;  

            if (findOptions.IsAsNoTracking && findOptions.IsIgnoreAutoIncludes)
            {
                query = query.IgnoreAutoIncludes().AsNoTracking();
            }
            else if (findOptions.IsIgnoreAutoIncludes)
            {
                query = query.IgnoreAutoIncludes();
            }
            else if (findOptions.IsAsNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

    }
}
