using Volo.Abp.Modularity;

namespace HRS.OrganChart;

[DependsOn(
    typeof(OrganChartApplicationModule),
    typeof(OrganChartDomainTestModule)
    )]
public class OrganChartApplicationTestModule : AbpModule
{

}
