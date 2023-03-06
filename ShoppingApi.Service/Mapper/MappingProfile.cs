using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Dto.Dtos;

namespace ShoppingApi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap()
                .ForMember(dest => dest.ShoppingList, opt => opt.MapFrom(src => src.ShoppingList.Name));
            CreateMap<ShoppingListDto, ShoppingList>().ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
