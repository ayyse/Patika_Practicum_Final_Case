namespace ShoppingApi.Service.Abstract.Command
{
    public interface ICommandBaseService<Dto, Entity>
    {
        Task InsertAsync(Dto insertResource);
        Task UpdateAsync(int id, Dto updateResource);
        Task RemoveAsync(int id);
    }
}
