using HRS.OrganChart.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HRS.OrganChart;

public abstract class OrganChartController : AbpControllerBase
{
    protected OrganChartController()
    {
        LocalizationResource = typeof(OrganChartResource);
    }
}
