using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Dto.Dtos;
using ShoppingApi.Service.Abstract.Query;

namespace ShoppingApi.Service.Concrete.Query
{
    public class QueryUserService : QueryBaseService<UserDto, User>, IQueryUserService
    {
        public QueryUserService(IUserRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
