using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HRS.Employee.EMPSamples;

public class SampleEMPAppService : EmployeeAppService, ISampleEMPAppService
{
    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    public void GetCaptchaImage()
    {

    }


}
