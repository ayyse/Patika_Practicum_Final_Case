using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data.Context;
using ShoppingApi.Service.Mapper;

namespace ShoppingApiTests.TestDatabase
{
    public class CommonTestFixture
    {
        public ShoppingApiDbContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<ShoppingApiDbContext>().UseInMemoryDatabase(databaseName: "ShoppingApiDatabase").Options;
            _context = new ShoppingApiDbContext(options);
            _context.Database.EnsureCreated(); // context oluşturulduğundan emin olmak için

            _context.AddCategories();
            _context.SaveChanges();

            _mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
