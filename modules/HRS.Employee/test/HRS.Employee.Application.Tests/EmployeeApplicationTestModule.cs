using Volo.Abp.Modularity;

namespace HRS.Employee;

[DependsOn(
    typeof(EmployeeApplicationModule),
    typeof(EmployeeDomainTestModule)
    )]
public class EmployeeApplicationTestModule : AbpModule
{

}
