using CCM.Models;
using CCM.Services;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class TransactionRepository(CcmContext context)
{
    public async Task<List<Transaction>> ListAllAsync()
    {
        return await context.Transactions
            .Include(transaction => transaction.Card)
            .Include(transaction => transaction.Store)
            .ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(ulong id)
    {
        return await context.Transactions
            .Include(transaction => transaction.Card)
            .Include(transaction => transaction.Store)
            .FirstOrDefaultAsync(x => x.Id == id);
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

    public async Task<Transaction?> UpdateByVpBankLog(VPBankTransactionLog? vpBankTransactionLog)
    {
        if (vpBankTransactionLog != null)
        {
            var existingTransaction = await context.Transactions
                .FirstOrDefaultAsync(t => t.Code == vpBankTransactionLog.TransactionCode);

            if (existingTransaction != null)
            {
                existingTransaction.StatusId = 2;
                existingTransaction.UpdatedAt = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return existingTransaction;
            }
        }

        return null;
    }
}