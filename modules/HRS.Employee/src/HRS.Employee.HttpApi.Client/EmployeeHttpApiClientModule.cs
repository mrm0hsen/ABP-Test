using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HRS.Employee;

[DependsOn(
    typeof(EmployeeApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class EmployeeHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(EmployeeApplicationContractsModule).Assembly,
            EmployeeRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EmployeeHttpApiClientModule>();
        });

    }
}
