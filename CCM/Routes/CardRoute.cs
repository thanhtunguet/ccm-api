namespace CCM.Routes;

public static class CardRoute
{
    public const string ApiPrefix = "api/card";
    public const string List = "list";
    public const string GetById = "{id}";
    public const string Create = "create";
    public const string Update = "update/{id}";
    public const string Delete = "delete/{id}";
    public const string Count = "count";
    public const string ListByType = "list-by-type";
    public const string CountByType = "count-by-type";
    public const string SyncBin = "sync-bin";
}