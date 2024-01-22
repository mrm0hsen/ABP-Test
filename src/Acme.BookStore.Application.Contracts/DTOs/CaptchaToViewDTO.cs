using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.DTOs
{
    public class CaptchaToViewDTO
    {
        public SideDTO Side1 { get; set; }
        public SideDTO Side2 { get; set; }
        public Guid CaptchaId { get; set; }
    }

    public class CaptchaResult
    {
        public bool result { get; set; } = false;
        public SideDTO? Side1 { get; set; }
        public SideDTO? Side2 { get; set; }
        public Guid? CaptchaId { get; set; }
    }

    public class SideDTO
    {
        public byte[] Side { get; set; }
        public int SideNumber { get; set; }
    }
}
