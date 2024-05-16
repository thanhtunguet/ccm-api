using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(TransactionRoute.ApiPrefix)]
public class TransactionController(TransactionService service) : ControllerBase
{
    [HttpPost(TransactionRoute.List)]
    public Task<List<Transaction>> GetAllTransactions()
    {
        return service.ListAllTransactionsAsync();
    }

    [HttpPost(TransactionRoute.GetById)]
    public Task<Transaction> GetTransactionById(ulong id)
    {
        return service.GetTransactionByIdAsync(id);
    }

    [HttpPost(TransactionRoute.Create)]
    public Task CreateTransaction(Transaction transaction)
    {
        return service.CreateTransactionAsync(transaction);
    }

    [HttpPost(TransactionRoute.Update)]
    public Task UpdateTransaction(ulong id, Transaction transaction)
    {
        transaction.Id = id; // Ensure the provided id matches the entity id
        return service.UpdateTransactionAsync(transaction);
    }

    [HttpPost(TransactionRoute.Delete)]
    public Task DeleteTransaction(ulong id)
    {
        return service.DeleteTransactionAsync(id);
    }

    [HttpPost(TransactionRoute.Count)]
    public Task<int> GetTransactionCount()
    {
        return service.CountTransactionsAsync();
    }

    [HttpPost("update-vpbank-logs")]
    public async Task<IActionResult> UpdateTransactionLogs([FromBody] List<string> transactionLogs)
    {
        if (transactionLogs == null || !transactionLogs.Any()) return BadRequest("Transaction logs are required.");

        var updatedTransactions = new List<Transaction>();

        foreach (var log in transactionLogs)
        {
            if (string.IsNullOrWhiteSpace(log)) continue; // Ignore empty lines

            var updatedTransaction = await service.UpdateByVpBankLog(log);
            if (updatedTransaction != null) updatedTransactions.Add(updatedTransaction);
        }

        return Ok(updatedTransactions);
    }
}