using AutoMapper;
using ShoppingApi.Data.Context;
using ShoppingApiTests.TestDatabase;
using ShoppingApiTests.Tests.Abstract.Command.Delete;

namespace ShoppingApiTests.Tests.Concrete.Command.Delete
{
    public class CommandDeleteUserServiceTests : ICommandDeleteTests
    {
        private readonly ShoppingApiDbContext _context;
        private readonly IMapper _mapper;

        public CommandDeleteUserServiceTests(CommonTestFixture testFixture)
        {
            _context = testFixture._context;
            _mapper = testFixture._mapper;
        }

        public void WhenEntityIsNull_InvalidOperationException_ShouldBeReturn()
        {
            throw new NotImplementedException();
        }

        public void WhenValidIdIsGiven_Entity_ShouldBeDeleted()
        {
            throw new NotImplementedException();
        }
    }
}
