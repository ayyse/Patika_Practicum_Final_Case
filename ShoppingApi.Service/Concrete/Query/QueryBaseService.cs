using AutoMapper;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Service.Concrete.Query
{
    public abstract class QueryBaseService<Dto, Entity> : IQueryBaseService<Dto, Entity> where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        private readonly IMapper _mapper;

        public QueryBaseService(IGenericRepository<Entity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Dto>> GetAllAsync()
        {
            var entity = await _genericRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Dto>>(entity);
            return result;
        }

        public async Task<Dto> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            if (entity is null)
                throw new InvalidOperationException("Entity is null");

            var result = _mapper.Map<Dto>(entity);
            return result;
        }
    }
}
