using ShoppingApi.Data.Context;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.Repository.Concrete;
using ShoppingApi.Data.UnitOfWork.Abstract;

namespace ShoppingApi.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingApiDbContext _context;
        public bool disposed;

        public IGenericRepository<Category> CategoryRepository { get; private set; }
        public IGenericRepository<Product> ProductRepository { get; private set; }
        public IGenericRepository<ShoppingList> ShoppingListRepository { get; private set; }


        public UnitOfWork(ShoppingApiDbContext context)
        {
            _context = context;

            CategoryRepository = new GenericRepository<Category>(_context);
            ProductRepository = new GenericRepository<Product>(_context);
            ShoppingListRepository = new GenericRepository<ShoppingList>(_context);
        }



        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges(); // yazma metotları son adım
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging                    
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
