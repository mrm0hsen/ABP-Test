using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace HRS.Employee;

[DependsOn(
    typeof(EmployeeDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class EmployeeApplicationContractsModule : AbpModule
{

}
