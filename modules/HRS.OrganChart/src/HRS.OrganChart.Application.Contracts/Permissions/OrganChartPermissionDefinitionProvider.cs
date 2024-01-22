using HRS.OrganChart.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HRS.OrganChart.Permissions;

public class OrganChartPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OrganChartPermissions.GroupName, L("Permission:OrganChart"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OrganChartResource>(name);
    }
}
