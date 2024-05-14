namespace CCM.Models;

public class Card
{
    public ulong Id { get; set; }

    public ulong? CardClassId { get; set; }

    public ulong? CustomerId { get; set; }

    public string Number { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual CardClass? CardClass { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}