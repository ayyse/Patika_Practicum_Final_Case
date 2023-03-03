using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.UnitOfWork.Abstract;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Command;

namespace ShoppingApi.Service.Concrete.Command
{
    public class CommandShoppingListService : CommandBaseService<ShoppingListDto, ShoppingList>, ICommandShoppingListService
    {
        public CommandShoppingListService(IGenericRepository<ShoppingList> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
        }
    }
}
