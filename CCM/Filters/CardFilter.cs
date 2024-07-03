using CCM.Core;

namespace CCM.Filters;

public static class CardType
{
    public const int All = 1;

    public const int StatementDate = 2;

    public const int DueDate = 3;
}

public class CardFilter : DataFilter
{
    public int? CardTypeId { get; set; } // Added cardTypeId property
}
