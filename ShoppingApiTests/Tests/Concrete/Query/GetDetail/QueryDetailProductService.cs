using AutoMapper;
using ShoppingApi.Data.Context;
using ShoppingApiTests.TestDatabase;
using ShoppingApiTests.Tests.Abstract.Query.GetDetail;

namespace ShoppingApiTests.Tests.Concrete.Query.GetDetail
{
    public class QueryDetailProductService : IQueryDetailTests
    {
        private readonly ShoppingApiDbContext _context;
        private readonly IMapper _mapper;

        public QueryDetailProductService(CommonTestFixture testFixture)
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
