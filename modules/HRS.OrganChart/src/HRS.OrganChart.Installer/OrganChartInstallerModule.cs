using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HRS.OrganChart;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class OrganChartInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrganChartInstallerModule>();
        });
    }
}
