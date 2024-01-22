namespace HRS.OrganChart;

public static class OrganChartDbProperties
{
    public static string DbTablePrefix { get; set; } = "OrganChart";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "OrganChart";
}
