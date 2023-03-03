namespace ShoppingApi.Service.Abstract.Command
{
    public interface ICommandBaseService<Dto, Entity>
    {
        void InsertAsync(Dto insertResource);
        void UpdateAsync(int id, Dto updateResource);
        void RemoveAsync(int id);
    }
}
