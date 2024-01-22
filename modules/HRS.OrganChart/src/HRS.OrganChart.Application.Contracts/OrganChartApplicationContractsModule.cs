using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace HRS.OrganChart;

[DependsOn(
    typeof(OrganChartDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class OrganChartApplicationContractsModule : AbpModule
{

}
