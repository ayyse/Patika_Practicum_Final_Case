﻿using AutoMapper;
using ShoppingApi.Data.Model;
using ShoppingApi.Dto.Dtos;

namespace ShoppingApi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ShoppingListDto, ShoppingList>().ReverseMap();
        }
    }
}