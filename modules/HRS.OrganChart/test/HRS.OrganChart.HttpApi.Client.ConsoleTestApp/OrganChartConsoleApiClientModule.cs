using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace HRS.OrganChart;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OrganChartHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class OrganChartConsoleApiClientModule : AbpModule
{

}
