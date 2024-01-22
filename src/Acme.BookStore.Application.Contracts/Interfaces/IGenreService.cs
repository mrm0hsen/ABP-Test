using Acme.BookStore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Interfaces
{
    public interface IGenreService : ICrudAppService<
        GenreDTO,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateGenreDTO,
        UpdateGenreDTO>
    {
    }
}
