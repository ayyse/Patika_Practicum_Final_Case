using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;

namespace ShoppingApi.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<ShoppingList> ShoppingListRepository { get; }

        Task CompleteAsync();
    }
}
