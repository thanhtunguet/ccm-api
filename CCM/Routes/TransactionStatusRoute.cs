namespace CCM.Routes;

public static class TransactionStatusRoute
{
    public const string ApiPrefix = "api/transaction-status";
    public const string List = "list";
    public const string GetById = "{id}";
    public const string Create = "create";
    public const string Update = "update/{id}";
    public const string Delete = "delete/{id}";
    public const string Count = "count";
}