using AutoMapper;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.Repository.Concrete;
using ShoppingApi.Data.UnitOfWork.Abstract;
using ShoppingApi.Data.UnitOfWork.Concrete;
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
        public async void InsertAsync(Dto insertResource)
        {
            var entity = _mapper.Map<Entity>(insertResource);

            await _genericRepository.InsertAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async void RemoveAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            _genericRepository.RemoveAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async void UpdateAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            _genericRepository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
