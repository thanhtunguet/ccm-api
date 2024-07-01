using CCM.Core;
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Repositories;

public class TransactionRepository(CcmContext context) : GenericRepository<Transaction>(context)
{
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