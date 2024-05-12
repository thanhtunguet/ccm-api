using System;
using System.Collections.Generic;

namespace CCM.Models;

public partial class TransactionStatus
{
    public const int Pending = 1;

    public const int Done = 2;

    public ulong Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}