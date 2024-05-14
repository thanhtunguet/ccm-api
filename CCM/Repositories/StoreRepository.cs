using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class StoreRepository(CcmContext context)
{
    public async Task<List<Store>> ListAllAsync()
    {
        return await context.Stores.ToListAsync();
    }

    public async Task<Store> GetByIdAsync(ulong id)
    {
        return await context.Stores.FindAsync(id);
    }

    public async Task CreateAsync(Store store)
    {
        context.Stores.Add(store);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Store store)
    {
        context.Entry(store).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ulong id)
    {
        var store = await context.Stores.FindAsync(id);
        context.Stores.Remove(store);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await context.Stores.CountAsync();
    }
}