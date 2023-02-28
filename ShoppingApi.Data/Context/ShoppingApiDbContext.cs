using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data.Model;

namespace ShoppingApi.Data.Context
{
    public class ShoppingApiDbContext : DbContext
    {
        public ShoppingApiDbContext(DbContextOptions<ShoppingApiDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
