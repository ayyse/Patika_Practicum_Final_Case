using AutoMapper;
using ShoppingApi.Data.Context;
using ShoppingApiTests.TestDatabase;
using ShoppingApiTests.Tests.Abstract.Query.GetDetail;

namespace ShoppingApiTests.Tests.Concrete.Query.GetDetail
{
    public class QueryDetailShoppingListService : IQueryDetailTests
    {
        private readonly ShoppingApiDbContext _context;
        private readonly IMapper _mapper;

        public QueryDetailShoppingListService(CommonTestFixture testFixture)
        {
            _context = testFixture._context;
            _mapper = testFixture._mapper;
        }

        public void WhenEntityIsNull_InvalidOperationException_ShouldBeReturn()
        {
            throw new NotImplementedException();
        }

        public void WhenValidInputsAreGiven_Entity_ShouldBeGetDetail()
        {
            throw new NotImplementedException();
        }
    }
}
