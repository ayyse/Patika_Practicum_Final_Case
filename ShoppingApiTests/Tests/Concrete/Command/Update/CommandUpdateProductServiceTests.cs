using AutoMapper;
using ShoppingApi.Data.Context;
using ShoppingApiTests.TestDatabase;
using ShoppingApiTests.Tests.Abstract.Command.Update;

namespace ShoppingApiTests.Tests.Concrete.Command.Update
{
    public class CommandUpdateProductServiceTests : ICommandUpdateTests
    {
        private readonly ShoppingApiDbContext _context;
        private readonly IMapper _mapper;

        public CommandUpdateProductServiceTests(CommonTestFixture testFixture)
        {
            _context = testFixture._context;
            _mapper = testFixture._mapper;
        }

        public void WhenEntityIsNull_InvalidOperationException_ShouldBeReturn()
        {
            throw new NotImplementedException();
        }

        public void WhenValidInputsAreGiven_Entity_ShouldBeUpdated()
        {
            throw new NotImplementedException();
        }
    }
}
