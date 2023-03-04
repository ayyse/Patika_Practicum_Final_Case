using ShoppingApi.Data.Model;
using ShoppingApi.Dto.Dtos;

namespace ShoppingApi.Service.Abstract.Query
{
    public interface IQueryShoppingListService : IQueryBaseService<ShoppingListDto, ShoppingList>
    {
        Task<IEnumerable<ShoppingListDto>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<ShoppingListDto>> GetByCreateDateAsync(DateTime createDate);
        Task<IEnumerable<ShoppingListDto>> GetByCompleteDateAsync(DateTime completeDate);
    }
}
