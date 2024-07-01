using CCM.Core;
using CCM.Models;
using CCM.Routes;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.Controllers;

[ApiController]
[Route(TransactionRoute.ApiPrefix)]
public class TransactionController(TransactionService service) : GenericController<Transaction>(service)
{
    [HttpPost(TransactionRoute.UpdateVpBankLog)]
    public async Task<IActionResult> UpdateTransactionLogs([FromBody] List<string>? transactionLogs)
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