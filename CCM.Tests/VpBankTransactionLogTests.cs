using CCM.Models;

namespace CCM.Tests;

[TestFixture]
public class VpBankTransactionLogTests
{
    [Test]
    public void Parse_ValidLogString_ReturnsCorrectTransactionLog()
    {
        // Arrange
        var log =
            "TT MC CHO TID R1430747 NGAY GD 24/04/30 07.52.28 SO THE 524394...1742 CODE 886172 SO TIEN 32596000 VND (1) PHI 391152VND VAT 39115VND TG 1 RRN 412189474136";

        // Act
        var transactionLog = VPBankTransactionLog.Parse(log);

        // Assert
        Assert.That(transactionLog.TID, Is.EqualTo("R1430747"));
        Assert.That(transactionLog.CreatedDate, Is.EqualTo(new DateTime(2024, 04, 30, 07, 52, 28)));
        Assert.That(transactionLog.CardNumber, Is.EqualTo("524394...1742"));
        Assert.That(transactionLog.TransactionCode, Is.EqualTo("412189474136"));
        Assert.That(transactionLog.Amount, Is.EqualTo(32596000m));
        Assert.That(transactionLog.Fee, Is.EqualTo(391152m));
        Assert.That(transactionLog.VAT, Is.EqualTo(39115m));
    }

    [Test]
    public void Parse_InvalidLogString_ReturnsDefaultTransactionLog()
    {
        // Arrange
        var log = "Invalid log string";

        // Act
        var transactionLog = VPBankTransactionLog.Parse(log);

        // Assert
        Assert.IsNull(transactionLog.TID);
        Assert.That(transactionLog.CreatedDate, Is.EqualTo(default(DateTime)));
        Assert.IsNull(transactionLog.CardNumber);
        Assert.IsNull(transactionLog.TransactionCode);
        Assert.That(transactionLog.Amount, Is.EqualTo(0m));
        Assert.That(transactionLog.Fee, Is.EqualTo(0m));
        Assert.That(transactionLog.VAT, Is.EqualTo(0m));
    }

    [Test]
    public void Parse_PartiallyValidLogString_ReturnsPartiallyParsedTransactionLog()
    {
        // Arrange
        var log =
            "\"TT VISA CHO TID R1430866 NGAY GD 24/05/01 16.21.00 SO THE 428695...2108 CODE 191657 SO TIEN\n29004000 VND (1) PHI 348048VND VAT 34805VND TG 1 RRN 412289654189\"\t\t\t\t\t\t\t";

        // Act
        var transactionLog = VPBankTransactionLog.Parse(log);

        // Assert
        Assert.That(transactionLog.TID, Is.EqualTo("R1430866"));
        Assert.That(transactionLog.CreatedDate, Is.EqualTo(new DateTime(2024, 05, 01, 16, 21, 00)));
        Assert.That(transactionLog.CardNumber, Is.EqualTo("428695...2108"));
        Assert.That(transactionLog.TransactionCode, Is.EqualTo("412289654189"));
        Assert.That(transactionLog.Amount, Is.EqualTo(29004000m));
        Assert.That(transactionLog.Fee, Is.EqualTo(348048m));
        Assert.That(transactionLog.VAT, Is.EqualTo(34805m));
    }

    [Test]
    [TestCase(
        "TID R1430747 NGAY GD 24/04/30 07.52.28 SO THE 524394...1742 CODE 886172 SO TIEN 32596000 VND (1) PHI 391152VND VAT 39115VND TG 1 RRN 412189474136",
        "R1430747",
        "524394...1742",
        "412189474136",
        32596000,
        391152,
        39115
    )]
    [TestCase(
        "TID A1234567 NGAY GD 21/05/15 12.30.45 SO THE 123456...7890 CODE 123456 SO TIEN 100000 VND (1) PHI 1000VND VAT 100VND TG 1 RRN 987654321000",
        "A1234567",
        "123456...7890",
        "987654321000",
        100000,
        1000,
        100
    )]
    [TestCase(
        "\"TT MC CHO TID R1430866 NGAY GD 24/05/02 09.59.22 SO THE\n516101...4062 CODE 973312 SO TIEN\n27499000 VND (1) PHI 329988VND VAT 32999VND TG 1 RRN 412389754425\"\t\t\t\t\t\t\t",
        "R1430866",
        "516101...4062",
        "412389754425",
        27499000,
        329988,
        32999
    )]
    public void Parse_ValidLogStringsWithTestCase_ReturnsCorrectTransactionLogs(string log, string expectedTid,
        string expectedCardNumber, string expectedTransactionCode, decimal expectedAmount, decimal expectedFee,
        decimal expectedVat)
    {
        // Act
        var transactionLog = VPBankTransactionLog.Parse(log);

        // Assert
        Assert.That(transactionLog.TID, Is.EqualTo(expectedTid));
        Assert.That(transactionLog.CardNumber, Is.EqualTo(expectedCardNumber));
        Assert.That(transactionLog.TransactionCode, Is.EqualTo(expectedTransactionCode));
        Assert.That(transactionLog.Amount, Is.EqualTo(expectedAmount));
        Assert.That(transactionLog.Fee, Is.EqualTo(expectedFee));
        Assert.That(transactionLog.VAT, Is.EqualTo(expectedVat));
    }
}