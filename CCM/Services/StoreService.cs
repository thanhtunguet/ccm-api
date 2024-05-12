using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services
{
    public class StoreService
    {
        private readonly StoreRepository _repository;

        public StoreService(StoreRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Store>> ListAllStoresAsync()
        {
            return _repository.ListAllAsync();
        }

        public Task<Store> GetStoreByIdAsync(ulong id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task CreateStoreAsync(Store store)
        {
            return _repository.CreateAsync(store);
        }

        public Task UpdateStoreAsync(Store store)
        {
            return _repository.UpdateAsync(store);
        }

        public Task DeleteStoreAsync(ulong id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<int> CountStoresAsync()
        {
            return _repository.CountAsync();
        }
    }
}