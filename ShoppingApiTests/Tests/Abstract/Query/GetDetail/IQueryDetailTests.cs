namespace ShoppingApiTests.Tests.Abstract.Query.GetDetail
{
    public interface IQueryDetailTests
    {
        void WhenEntityIsNull_InvalidOperationException_ShouldBeReturn();
        void WhenValidInputsAreGiven_Entity_ShouldBeGetDetail();
    }
}
