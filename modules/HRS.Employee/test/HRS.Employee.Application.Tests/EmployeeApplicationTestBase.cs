using Volo.Abp.Modularity;

namespace HRS.Employee;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class EmployeeApplicationTestBase<TStartupModule> : EmployeeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
