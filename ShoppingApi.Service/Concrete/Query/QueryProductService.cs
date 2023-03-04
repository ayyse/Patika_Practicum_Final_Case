using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.Repository.Concrete;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Service.Concrete.Query
{
    public class QueryProductService : QueryBaseService<ProductDto, Product>, IQueryProductService
    {
        private readonly IProductRepository _genericRepository;
        private readonly IMapper _mapper;
        public QueryProductService(IProductRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetByShoppingListIdAsync(int shoppingListId)
        {
            var entity = await _genericRepository.GetByShoppingListIdAsync(shoppingListId);
            var result = _mapper.Map<IEnumerable<ProductDto>>(entity);

            return result;
        }
    }
}
