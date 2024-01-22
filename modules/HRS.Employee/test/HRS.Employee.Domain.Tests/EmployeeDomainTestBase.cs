using Volo.Abp.Modularity;

namespace HRS.Employee;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class EmployeeDomainTestBase<TStartupModule> : EmployeeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
