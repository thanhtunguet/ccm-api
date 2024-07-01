namespace CCM.Core;

public class DataFilter
{
    public const string Desc = "DESC";

    public const string Asc = "ASC";

    public int Skip { get; set; } = 0;

    public int Take { get; set; } = 10;

    public string? Search { get; set; }

    public string? OrderBy { get; set; }

    public string? OrderType { get; set; }
}