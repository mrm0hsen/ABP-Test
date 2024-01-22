using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace HRS.Employee;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(EmployeeDomainSharedModule)
)]
public class EmployeeDomainModule : AbpModule
{

}
