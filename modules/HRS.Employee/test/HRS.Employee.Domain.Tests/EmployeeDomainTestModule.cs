using Volo.Abp.Modularity;

namespace HRS.Employee;

[DependsOn(
    typeof(EmployeeDomainModule),
    typeof(EmployeeTestBaseModule)
)]
public class EmployeeDomainTestModule : AbpModule
{

}
