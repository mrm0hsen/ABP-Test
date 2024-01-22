using HRS.Employee.Localization;
using Volo.Abp.Application.Services;

namespace HRS.Employee;

public abstract class EmployeeAppService : ApplicationService
{
    protected EmployeeAppService()
    {
        LocalizationResource = typeof(EmployeeResource);
        ObjectMapperContext = typeof(EmployeeApplicationModule);
    }
}
