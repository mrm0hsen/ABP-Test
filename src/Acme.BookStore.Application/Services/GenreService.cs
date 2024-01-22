using Acme.BookStore.DTOs;
using Acme.BookStore.Entities;
using Acme.BookStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Services
{
    public class GenreService : CrudAppService<
        Genre,
        GenreDTO,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateGenreDTO,
        UpdateGenreDTO>, IGenreService
    {
        public GenreService(IRepository<Genre, Guid> repository) : base(repository)
        {
        }
    }
}
