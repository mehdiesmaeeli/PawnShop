namespace PawnShop.App.Contract.Services
{
    public interface IGenericService<TEntity, TViewModel> where TEntity : class
    {
        Task<IEnumerable<TViewModel>> GetAllAsync();
        Task<TViewModel> GetByIdAsync(Guid id);
        Task<TViewModel> CreateAsync(TViewModel entity);
        Task<TViewModel> UpdateAsync(TViewModel entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
