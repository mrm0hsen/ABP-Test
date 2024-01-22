using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace HRS.Employee;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EmployeeHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class EmployeeConsoleApiClientModule : AbpModule
{

}
