using CCM.Core;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class TransactionService(TransactionRepository repository) : GenericService<Transaction>(repository)
{
    public async Task<Transaction?> UpdateByVpBankLog(string log)
    {
        var transactionLog = VPBankTransactionLog.Parse(log);
        return await repository.UpdateByVpBankLog(transactionLog);
    }
}
