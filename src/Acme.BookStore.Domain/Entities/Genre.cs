﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Entities
{
    public class Genre : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
