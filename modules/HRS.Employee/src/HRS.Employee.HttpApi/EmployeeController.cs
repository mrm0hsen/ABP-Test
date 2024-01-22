using HRS.Employee.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace HRS.Employee;

[Area(EmployeeRemoteServiceConsts.ModuleName)]
[RemoteService(Name = EmployeeRemoteServiceConsts.RemoteServiceName)]
[Route("api/Employee/sampleEMP")]
public abstract class EmployeeController : AbpControllerBase
{
    protected EmployeeController()
    {
        LocalizationResource = typeof(EmployeeResource);
    }
}
