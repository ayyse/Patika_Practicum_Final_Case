using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Service.Concrete.Query
{
    public class QueryShoppingListService : QueryBaseService<ShoppingListDto, ShoppingList>, IQueryShoppingListService
    {
        private readonly IShoppingListRepository _genericRepository;
        private readonly IMapper _mapper;
        public QueryShoppingListService(IShoppingListRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShoppingListDto>> GetByCategoryIdAsync(int categoryId)
        {
            var entity = await _genericRepository.GetByCategoryIdAsync(categoryId);
            var result = _mapper.Map<IEnumerable<ShoppingListDto>>(entity);

            return result;
        }

        public async Task<IEnumerable<ShoppingListDto>> GetByCreateDateAsync(DateTime createDate)
        {
            var entity = await _genericRepository.GetByCreateDateAsync(createDate);
            var result = _mapper.Map<IEnumerable<ShoppingListDto>>(entity);

            return result;
        }

        public async Task<IEnumerable<ShoppingListDto>> GetByCompleteDateAsync(DateTime completeDate)
        {
            var entity = await _genericRepository.GetByCompleteDateAsync(completeDate);
            var result = _mapper.Map<IEnumerable<ShoppingListDto>>(entity);

            return result;
        }
    }
}
