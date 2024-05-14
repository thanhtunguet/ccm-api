namespace CCM.Models;

public class Bank
{
    public ulong Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public string? EnglishName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CardClass> CardClasses { get; set; } = new List<CardClass>();
}