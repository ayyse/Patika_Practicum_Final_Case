using ShoppingApi.Data.Context;
using ShoppingApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApiTests.TestDatabase
{
    public static class Categories
    {
        public static void AddCategories(this ShoppingApiDbContext context)
        {
            context.Categories.AddRange(
                new Category
                {
                    Name = "Market Alışverişi",
                },
                new Category
                {
                    Name = "Okul Alışverişi",
                },
                new Category
                {
                    Name = "Kasap Alışverişi",
                },
                new Category
                {
                    Name = "Giyim Alışverişi",
                },
                new Category
                {
                    Name = "Evcil Hayvan Alışverişi",
                });
        }
    }
}
