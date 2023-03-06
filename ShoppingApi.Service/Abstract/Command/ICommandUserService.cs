using ShoppingApi.Data.Model;
using ShoppingApi.Dto.Dtos;

namespace ShoppingApi.Service.Abstract.Command
{
    public interface ICommandUserService : ICommandBaseService<UserDto, User>
    {
    }
}
