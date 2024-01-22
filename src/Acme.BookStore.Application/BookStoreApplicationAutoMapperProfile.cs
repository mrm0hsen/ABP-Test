using Acme.BookStore.DTOs;
using Acme.BookStore.Entities;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {

        CreateMap<GenreDTO, Genre>().ReverseMap();
        CreateMap<CreateGenreDTO, Genre>()
            .Ignore(x => x.Id)
            .ReverseMap();
        CreateMap<UpdateGenreDTO, Genre>()
            .Ignore(x => x.Id)
            .ReverseMap();

        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
