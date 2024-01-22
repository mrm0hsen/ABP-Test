using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.DTOs
{
    public class GenreDTO : EntityDto<Guid>
    {
        public string Name { get; set; }
    }

    public class CreateGenreDTO
    {
        public string Name { get; set; }
    }

    public class UpdateGenreDTO
    {
        public string Name { get; set; }
    }

}
