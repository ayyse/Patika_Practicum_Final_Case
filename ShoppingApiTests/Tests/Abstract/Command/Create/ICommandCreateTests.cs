namespace ShoppingApiTests.Tests.Abstract.Command.Create
{
    public interface ICommandCreateTests
    {
        void WhenAlreadyExistEntity_InvalidOperationException_ShouldBeReturn();
        void WhenValidInputsAreGiven_Entity_ShouldBeCreated();
    }
}
