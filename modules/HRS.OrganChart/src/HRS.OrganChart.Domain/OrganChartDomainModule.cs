using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace HRS.OrganChart;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(OrganChartDomainSharedModule)
)]
public class OrganChartDomainModule : AbpModule
{

}
