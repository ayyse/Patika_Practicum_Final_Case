using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data.Context;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;

namespace ShoppingApi.Data.Repository.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ShoppingApiDbContext _context;
        public ProductRepository(ShoppingApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetByShoppingListIdAsync(int shoppingListId)
        {
            var productsByShoppingListId = await _context.Products.Where(x => x.ShoppingListId == shoppingListId).ToListAsync();
            return productsByShoppingListId;
        }
    }
}
