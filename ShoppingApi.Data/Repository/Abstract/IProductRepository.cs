using ShoppingApi.Data.Model;

namespace ShoppingApi.Data.Repository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetByShoppingListIdAsync(int shoppingListId);
    }
}
