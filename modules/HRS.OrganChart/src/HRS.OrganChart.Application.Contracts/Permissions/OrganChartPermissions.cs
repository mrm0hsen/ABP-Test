using Volo.Abp.Reflection;

namespace HRS.OrganChart.Permissions;

public class OrganChartPermissions
{
    public const string GroupName = "OrganChart";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(OrganChartPermissions));
    }
}
