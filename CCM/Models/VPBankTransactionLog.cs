using System.Globalization;
using System.Text.RegularExpressions;

namespace CCM.Models;

public class VPBankTransactionLog
{
    public string TID { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CardNumber { get; set; }
    public string TransactionCode { get; set; }
    public decimal Amount { get; set; }
    public decimal Fee { get; set; }
    public decimal VAT { get; set; }

    public static VPBankTransactionLog Parse(string log)
    {
        var transactionLog = new VPBankTransactionLog();

        // Regular expressions to extract the fields from the log
        var tidRegex = new Regex(@"TID\s+(\w+)");
        var dateRegex = new Regex(@"NGAY GD\s+(\d{2}/\d{2}/\d{2})\s+(\d{2}.\d{2}.\d{2})");
        var cardNumberRegex = new Regex(@"SO THE\s+(\d+(?:\.\.\.\d+)?)");
        var transactionCodeRegex = new Regex(@"RRN\s+(\d+)");
        var amountRegex = new Regex(@"SO TIEN\s+(\d+)\s+VND");
        var feeRegex = new Regex(@"PHI\s+(\d+)");
        var vatRegex = new Regex(@"VAT\s+(\d+)");

        // Match the regex patterns with the log string
        var tidMatch = tidRegex.Match(log);
        var dateMatch = dateRegex.Match(log);
        var cardNumberMatch = cardNumberRegex.Match(log);
        var transactionCodeMatch = transactionCodeRegex.Match(log);
        var amountMatch = amountRegex.Match(log);
        var feeMatch = feeRegex.Match(log);
        var vatMatch = vatRegex.Match(log);

        // Parse and assign the extracted values
        if (tidMatch.Success) transactionLog.TID = tidMatch.Groups[1].Value;

        if (dateMatch.Success)
        {
            var dateStr = dateMatch.Groups[1].Value;
            var timeStr = dateMatch.Groups[2].Value.Replace(".", ":");
            if (DateTime.TryParseExact(dateStr + " " + timeStr, "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var createdDate))
                transactionLog.CreatedDate = createdDate;
        }

        if (cardNumberMatch.Success) transactionLog.CardNumber = cardNumberMatch.Groups[1].Value;

        if (transactionCodeMatch.Success) transactionLog.TransactionCode = transactionCodeMatch.Groups[1].Value;

        if (amountMatch.Success && decimal.TryParse(amountMatch.Groups[1].Value, out var amount))
            transactionLog.Amount = amount;

        if (feeMatch.Success && decimal.TryParse(feeMatch.Groups[1].Value, out var fee)) transactionLog.Fee = fee;

        if (vatMatch.Success && decimal.TryParse(vatMatch.Groups[1].Value, out var vat)) transactionLog.VAT = vat;

        return transactionLog;
    }
}