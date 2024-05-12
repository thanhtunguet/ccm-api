namespace CCM.Models;

public class Transaction
{
    public ulong Id { get; set; }

    public ulong? StoreId { get; set; }

    public ulong? StatusId { get; set; }

    public ulong CardId { get; set; }

    /// <summary>
    ///     (TID)
    /// </summary>
    public string Code { get; set; } = null!;

    public double? Amount { get; set; }

    public double? Fee { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Card? Card { get; set; } = null!;

    public virtual TransactionStatus? Status { get; set; }

    public virtual Store? Store { get; set; }
}