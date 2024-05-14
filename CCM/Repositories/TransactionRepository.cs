using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class TransactionRepository(CcmContext context)
{
    public async Task<List<Transaction>> ListAllAsync()
    {
        return await context.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(ulong id)
    {
        return await context.Transactions.FindAsync(id);
    }

    public async Task CreateAsync(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        context.Entry(transaction).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ulong id)
    {
        var transaction = await context.Transactions.FindAsync(id);
        context.Transactions.Remove(transaction);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await context.Transactions.CountAsync();
    }
}