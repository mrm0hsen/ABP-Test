using Volo.Abp.Modularity;

namespace HRS.OrganChart;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class OrganChartApplicationTestBase<TStartupModule> : OrganChartTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
