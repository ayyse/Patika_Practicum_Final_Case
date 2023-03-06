using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data.Context;
using ShoppingApi.Data.Repository.Abstract;
using System.Linq.Expressions;

namespace ShoppingApi.Data.Repository.Concrete
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ShoppingApiDbContext _context;
        private DbSet<Entity> _entities;
        public GenericRepository(ShoppingApiDbContext context)
        {
            _context = context;
            _entities = _context.Set<Entity>();
        }

        public virtual async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int entityId)
        {
            return await _entities.FindAsync(entityId);
        }

        public async Task InsertAsync(Entity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(Entity entity)
        {
            _entities.Update(entity);
        }

        public void RemoveAsync(Entity entity)
        {
            var column = entity.GetType().GetProperty("IsDeleted");
            if (column is not null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            }
            else
            {
                _entities.Remove(entity);
            }
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where)
        {
            return _entities.Where(where).AsQueryable();
        }
    }
}
