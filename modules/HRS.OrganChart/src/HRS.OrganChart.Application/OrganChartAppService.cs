using HRS.OrganChart.Localization;
using Volo.Abp.Application.Services;

namespace HRS.OrganChart;

public abstract class OrganChartAppService : ApplicationService
{
    protected OrganChartAppService()
    {
        LocalizationResource = typeof(OrganChartResource);
        ObjectMapperContext = typeof(OrganChartApplicationModule);
    }
}
