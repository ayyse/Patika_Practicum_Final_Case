using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.UnitOfWork.Abstract;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Command;

namespace ShoppingApi.Service.Concrete.Command
{
    public class CommandProductService : CommandBaseService<ProductDto, Product>, ICommandProductService
    {
        public CommandProductService(IGenericRepository<Product> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
        }
    }
}
