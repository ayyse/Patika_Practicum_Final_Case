using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Service.Concrete.Query
{
    public class QueryShoppingListService : QueryBaseService<ShoppingListDto, ShoppingList>, IQueryShoppingListService
    {
        public QueryShoppingListService(IGenericRepository<ShoppingList> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
