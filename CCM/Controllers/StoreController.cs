using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Controllers
{
    [ApiController]
    [Route(StoreRoute.ApiPrefix)]
    public class StoreController : ControllerBase
    {
        private readonly StoreService _service;

        public StoreController(StoreService service)
        {
            _service = service;
        }

        [HttpPost(StoreRoute.List)]
        public Task<List<Store>> GetAllStores()
        {
            return _service.ListAllStoresAsync();
        }

        [HttpPost(StoreRoute.GetById)]
        public Task<Store> GetStoreById(ulong id)
        {
            return _service.GetStoreByIdAsync(id);
        }

        [HttpPost(StoreRoute.Create)]
        public Task CreateStore(Store store)
        {
            return _service.CreateStoreAsync(store);
        }

        [HttpPost(StoreRoute.Update)]
        public Task UpdateStore(ulong id, Store store)
        {
            store.Id = id; // Ensure the provided id matches the entity id
            return _service.UpdateStoreAsync(store);
        }

        [HttpPost(StoreRoute.Delete)]
        public Task DeleteStore(ulong id)
        {
            return _service.DeleteStoreAsync(id);
        }

        [HttpPost(StoreRoute.Count)]
        public Task<int> GetStoreCount()
        {
            return _service.CountStoresAsync();
        }
    }
}