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
        var transactionLog = ParseVpBankLog(log);

        if (transactionLog != null) return await repository.UpdateByVpBankLog(transactionLog);

        return null;
    }

    private VPBankTransactionLog? ParseVpBankLog(string log)
    {
        var tidRegex = new Regex(@"TID\s+(\w+)");
        var dateRegex = new Regex(@"NGAY GD\s+(\d{2}/\d{2}/\d{2})\s+(\d{2}.\d{2}.\d{2})");
        var cardNumberRegex = new Regex(@"SO THE\s+(\d+)");
        var transactionCodeRegex = new Regex(@"CODE\s+(\d+)");
        var amountRegex = new Regex(@"SO TIEN\s+(\d+)\s+VND");
        var feeRegex = new Regex(@"PHI\s+(\d+)");
        var vatRegex = new Regex(@"VAT\s+(\d+)");

        var tidMatch = tidRegex.Match(log);
        var dateMatch = dateRegex.Match(log);
        var cardNumberMatch = cardNumberRegex.Match(log);
        var transactionCodeMatch = transactionCodeRegex.Match(log);
        var amountMatch = amountRegex.Match(log);
        var feeMatch = feeRegex.Match(log);
        var vatMatch = vatRegex.Match(log);

        if (tidMatch.Success && dateMatch.Success && cardNumberMatch.Success && transactionCodeMatch.Success &&
            amountMatch.Success && feeMatch.Success && vatMatch.Success)
        {
            var transactionLog = new VPBankTransactionLog
            {
                TID = tidMatch.Groups[1].Value,
                CreatedDate =
                    DateTime.ParseExact(dateMatch.Groups[1].Value + " " + dateMatch.Groups[2].Value.Replace(".", ":"),
                        "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture),
                CardNumber = cardNumberMatch.Groups[1].Value,
                TransactionCode = transactionCodeMatch.Groups[1].Value,
                Amount = decimal.Parse(amountMatch.Groups[1].Value),
                Fee = decimal.Parse(feeMatch.Groups[1].Value),
                VAT = decimal.Parse(vatMatch.Groups[1].Value)
            };

            return transactionLog;
        }

        return null;
    }
}