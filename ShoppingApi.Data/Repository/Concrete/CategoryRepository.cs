using ShoppingApi.Data.Context;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;

namespace ShoppingApi.Data.Repository.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShoppingApiDbContext context) : base(context)
        {
        }
    }
}
