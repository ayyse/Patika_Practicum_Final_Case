namespace ShoppingApi.Service.Abstract.Query
{
    public interface IQueryBaseService<Dto, Entity>
    {
        Task<IEnumerable<Dto>> GetAllAsync();
        Task<Dto> GetByIdAsync(int id);
    }
}
