using Acme.BookStore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore.Interfaces
{
    public interface ICaptcha : IApplicationService, ITransientDependency
    {
        Task<CaptchaToViewDTO> SendCaptcha();
    }
}
