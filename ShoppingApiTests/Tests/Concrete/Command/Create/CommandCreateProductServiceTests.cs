using AutoMapper;
using ShoppingApi.Data.Context;
using ShoppingApiTests.TestDatabase;
using ShoppingApiTests.Tests.Abstract.Command.Create;

namespace ShoppingApiTests.Tests.Concrete.Command.Create
{
    public class CommandCreateProductServiceTests : ICommandCreateTests
    {
        private readonly ShoppingApiDbContext _context;
        private readonly IMapper _mapper;

        public CommandCreateProductServiceTests(CommonTestFixture testFixture)
        {
            _context = testFixture._context;
            _mapper = testFixture._mapper;
        }

        public void WhenAlreadyExistEntity_InvalidOperationException_ShouldBeReturn()
        {
            throw new NotImplementedException();
        }

        public void WhenValidInputsAreGiven_Entity_ShouldBeCreated()
        {
            throw new NotImplementedException();
        }
    }
}
