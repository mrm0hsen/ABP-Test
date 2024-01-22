using Volo.Abp.Modularity;

namespace HRS.OrganChart;

[DependsOn(
    typeof(OrganChartDomainModule),
    typeof(OrganChartTestBaseModule)
)]
public class OrganChartDomainTestModule : AbpModule
{

}
