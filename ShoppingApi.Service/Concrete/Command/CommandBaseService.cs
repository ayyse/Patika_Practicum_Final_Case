using AutoMapper;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.UnitOfWork.Abstract;
using ShoppingApi.Service.Abstract.Command;

namespace ShoppingApi.Service.Concrete.Command
{
    public abstract class CommandBaseService<Dto, Entity> : ICommandBaseService<Dto, Entity> where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CommandBaseService(IGenericRepository<Entity> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task InsertAsync(Dto insertResource)
        {
            var entity = _mapper.Map<Entity>(insertResource);

            if (entity is not null)
                throw new InvalidOperationException("Entity already exists");

            await _genericRepository.InsertAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            if (entity is null)
                throw new InvalidOperationException("Entity is null");

            _genericRepository.RemoveAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public virtual async Task UpdateAsync(int id, Dto updateResource)
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            if (entity is null)
                throw new InvalidOperationException("Entity is null");

            _genericRepository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
