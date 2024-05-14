using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class StoreService(StoreRepository repository)
{
    public Task<List<Store>> ListAllStoresAsync()
    {
        return repository.ListAllAsync();
    }

    public Task<Store> GetStoreByIdAsync(ulong id)
    {
        return repository.GetByIdAsync(id);
    }

    public Task CreateStoreAsync(Store store)
    {
        return repository.CreateAsync(store);
    }

    public Task UpdateStoreAsync(Store store)
    {
        return repository.UpdateAsync(store);
    }

    public Task DeleteStoreAsync(ulong id)
    {
        return repository.DeleteAsync(id);
    }

    public Task<int> CountStoresAsync()
    {
        return repository.CountAsync();
    }
}