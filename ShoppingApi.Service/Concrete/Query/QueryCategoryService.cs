using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Service.Concrete.Query
{
    public class QueryCategoryService : QueryBaseService<CategoryDto, Category>, IQueryCategoryService
    {
        public QueryCategoryService(IGenericRepository<Category> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
