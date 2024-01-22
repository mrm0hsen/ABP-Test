using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HRS.OrganChart;

[DependsOn(
    typeof(OrganChartApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class OrganChartHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(OrganChartApplicationContractsModule).Assembly,
            OrganChartRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrganChartHttpApiClientModule>();
        });

    }
}
