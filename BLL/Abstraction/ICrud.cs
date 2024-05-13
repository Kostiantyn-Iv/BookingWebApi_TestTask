namespace BLL.Abstraction
{
    public interface ICrud<TModel>
        where TModel : class
    {
        public Task<IEnumerable<TModel>> GetAllAsync();

        public Task<TModel?> GetByKeyAsync(string key);

        public Task AddAsync(TModel entity);

        public Task DeleteByKeyAsync(string key);

        public Task UpdateAsync(TModel entity);
    }
}
