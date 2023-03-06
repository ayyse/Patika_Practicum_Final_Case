namespace ShoppingApi.Data.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int entityId);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void RemoveAsync(TEntity entity);
        IEnumerable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> where);
    }
}
