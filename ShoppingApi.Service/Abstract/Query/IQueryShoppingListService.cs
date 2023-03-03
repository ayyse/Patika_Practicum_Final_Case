﻿using ShoppingApi.Data.Model;
using ShoppingApi.Dto.Dtos;

namespace ShoppingApi.Service.Abstract.Query
{
    public interface IQueryShoppingListService : IQueryBaseService<ShoppingListDto, ShoppingList>
    {
    }
}
