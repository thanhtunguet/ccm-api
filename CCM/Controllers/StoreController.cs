using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(StoreRoute.ApiPrefix)]
public class StoreController(StoreService service) : ControllerBase
{
    [HttpPost(StoreRoute.List)]
    public Task<List<Store>> GetAllStores()
    {
        return service.ListAllStoresAsync();
    }

    [HttpPost(StoreRoute.GetById)]
    public Task<Store> GetStoreById(ulong id)
    {
        return service.GetStoreByIdAsync(id);
    }

    [HttpPost(StoreRoute.Create)]
    public Task CreateStore(Store store)
    {
        return service.CreateStoreAsync(store);
    }

    [HttpPost(StoreRoute.Update)]
    public Task UpdateStore(ulong id, Store store)
    {
        store.Id = id; // Ensure the provided id matches the entity id
        return service.UpdateStoreAsync(store);
    }

    [HttpPost(StoreRoute.Delete)]
    public Task DeleteStore(ulong id)
    {
        return service.DeleteStoreAsync(id);
    }

    [HttpPost(StoreRoute.Count)]
    public Task<int> GetStoreCount()
    {
        return service.CountStoresAsync();
    }
}