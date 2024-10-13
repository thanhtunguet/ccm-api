namespace CCM.Models;

public class TransactionStatus
{
    public static readonly TransactionStatus Pending = new TransactionStatus(
        1, "PENDING", "Chưa cập nhật", ""
    );

    public static readonly TransactionStatus Done = new TransactionStatus(
        2, "DONE", "Đã xuất", ""
    );

    public ulong Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    TransactionStatus(
        ulong id,
        string code,
        string name,
        string? color
    )
    {
        Id = id;
        Code = code;
        Name = name;
        Color = color;
    }
}