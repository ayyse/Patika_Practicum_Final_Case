﻿using ShoppingApi.Data.Model;
using ShoppingApi.Dto.Dtos;

namespace ShoppingApi.Service.Abstract.Command
{
    public interface ICommandCategoryService : ICommandBaseService<CategoryDto, Category>
    {
    }
}
