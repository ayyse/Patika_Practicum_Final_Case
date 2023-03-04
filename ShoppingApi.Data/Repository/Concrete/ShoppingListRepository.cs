﻿using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data.Context;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;

namespace ShoppingApi.Data.Repository.Concrete
{
    public class ShoppingListRepository : GenericRepository<ShoppingList>, IShoppingListRepository
    {
        private readonly ShoppingApiDbContext _context;
        public ShoppingListRepository(ShoppingApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShoppingList>> GetByCategoryIdAsync(int categoryId)
        {
            var shoppingListByCategoryId = await _context.ShoppingLists.Where(x => x.CategoryId == categoryId).ToListAsync();
            return shoppingListByCategoryId;
        }

        public async Task<IEnumerable<ShoppingList>> GetByCreateDateAsync(DateTime createDate)
        {
            var shoppingListByCreateDate = await _context.ShoppingLists.Where(x => x.CreateDate == createDate).ToListAsync();
            return shoppingListByCreateDate;
        }

        public async Task<IEnumerable<ShoppingList>> GetByCompleteDateAsync(DateTime completeDate)
        {
            var shoppingListByCompleteDate = await _context.ShoppingLists.Where(x => x.CompleteDate == completeDate).ToListAsync();
            return shoppingListByCompleteDate;
        }
    }
}
