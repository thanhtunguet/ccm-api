using System;
using System.Collections.Generic;

namespace CCM.Models;

public partial class CardClass
{
    public ulong Id { get; set; }

    public ulong BankId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Bin { get; set; }

    public long? DueDate { get; set; }

    public long? StatementDate { get; set; }

    public long? FreePeriod { get; set; }

    public string? SampleLink { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Bank Bank { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
