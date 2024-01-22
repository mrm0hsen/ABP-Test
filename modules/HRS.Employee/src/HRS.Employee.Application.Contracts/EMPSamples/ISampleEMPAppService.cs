using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HRS.Employee.EMPSamples;

public interface ISampleEMPAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
