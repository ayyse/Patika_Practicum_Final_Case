using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Service.Concrete.Query
{
    public class QueryProductService : QueryBaseService<ProductDto, Product>, IQueryProductService
    {
        public QueryProductService(IGenericRepository<Product> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
