namespace ShoppingApiTests.Tests.Abstract.Command.Update
{
    public interface ICommandUpdateTests
    {
        void WhenEntityIsNull_InvalidOperationException_ShouldBeReturn();
        void WhenValidInputsAreGiven_Entity_ShouldBeUpdated();
    }
}
