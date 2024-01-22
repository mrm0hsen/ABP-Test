using Localization.Resources.AbpUi;
using HRS.OrganChart.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace HRS.OrganChart;

[DependsOn(
    typeof(OrganChartApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class OrganChartHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(OrganChartHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<OrganChartResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
