namespace CCM.Core
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ListAllAsync(DataFilter filter);
        Task<int> CountAllAsync(DataFilter filter);
        Task<TEntity?> GetByIdAsync(ulong id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(ulong id);
    }

    public class GenericService<TEntity>(IGenericRepository<TEntity> repository) : IGenericService<TEntity>
        where TEntity : class
    {
        public async Task<IEnumerable<TEntity>> ListAllAsync(DataFilter filter)
        {
            return await repository.ListAllAsync(filter);
        }

        public async Task<int> CountAllAsync(DataFilter filter)
        {
            return await repository.CountAllAsync(filter);
        }

        public async Task<TEntity?> GetByIdAsync(ulong id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await repository.CreateAsync(entity);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(ulong id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}