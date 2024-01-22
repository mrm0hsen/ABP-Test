using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HRS.Employee;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class EmployeeInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EmployeeInstallerModule>();
        });
    }
}
