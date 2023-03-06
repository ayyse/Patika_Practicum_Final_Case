namespace ShoppingApiTests.Tests.Abstract.Command.Delete
{
    public interface ICommandDeleteTests
    {
        void WhenEntityIsNull_InvalidOperationException_ShouldBeReturn();
        void WhenValidIdIsGiven_Entity_ShouldBeDeleted();
    }
}
