using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace HRS.Employee.EMPSamples;

[Area(EmployeeRemoteServiceConsts.ModuleName)]
[RemoteService(Name = EmployeeRemoteServiceConsts.RemoteServiceName)]
[Route("api/Employee/sampleEMP")]
public class SampleEMPController : EmployeeController, ISampleEMPAppService
{
    private readonly ISampleEMPAppService _sampleAppService;

    public SampleEMPController(ISampleEMPAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }
}
