using System.Globalization;
using System.Text.RegularExpressions;
using CCM.Models;
using CCM.Repositories;

namespace CCM.Services;

public class TransactionService(TransactionRepository repository)
{
    public Task<List<Transaction>> ListAllTransactionsAsync()
    {
        return repository.ListAllAsync();
    }

    public Task<Transaction> GetTransactionByIdAsync(ulong id)
    {
        return repository.GetByIdAsync(id);
    }

    public Task CreateTransactionAsync(Transaction transaction)
    {
        return repository.CreateAsync(transaction);
    }

    public Task UpdateTransactionAsync(Transaction transaction)
    {
        return repository.UpdateAsync(transaction);
    }

    public Task DeleteTransactionAsync(ulong id)
    {
        return repository.DeleteAsync(id);
    }

    public Task<int> CountTransactionsAsync()
    {
        return repository.CountAsync();
    }

    public async Task<Transaction?> UpdateByVpBankLog(string log)
    {
        var transactionLog = VPBankTransactionLog.Parse(log);
        return await repository.UpdateByVpBankLog(transactionLog);
    }
}