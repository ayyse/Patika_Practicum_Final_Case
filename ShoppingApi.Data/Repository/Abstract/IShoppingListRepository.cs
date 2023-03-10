using ShoppingApi.Data.Model;

namespace ShoppingApi.Data.Repository.Abstract
{
    public interface IShoppingListRepository : IGenericRepository<ShoppingList>
    {
        Task<IEnumerable<ShoppingList>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ShoppingList>> GetByUserIdAsync(int userId);
        Task<IEnumerable<ShoppingList>> GetByCreateDateAsync(DateTime createDate);
        Task<IEnumerable<ShoppingList>> GetByCompleteDateAsync(DateTime completeDate);

        //Task<IEnumerable<ShoppingList>> GetWithCategoryAsync();
    }
}
