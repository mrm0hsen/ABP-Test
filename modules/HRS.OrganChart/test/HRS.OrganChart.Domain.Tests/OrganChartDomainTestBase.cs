using Volo.Abp.Modularity;

namespace HRS.OrganChart;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class OrganChartDomainTestBase<TStartupModule> : OrganChartTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
