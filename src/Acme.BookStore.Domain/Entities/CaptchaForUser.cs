using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Entities
{
    public class CaptchaForUser : Entity<Guid>
    {
        public string Answer { get; set; }

        public bool IsUsed { get; set; } = false;

        public DateTime InsertDate { get; set; } = DateTime.Now;

        public DateTime ExpireDate { get; set; } = DateTime.Now.AddMinutes(2);
    }
}
