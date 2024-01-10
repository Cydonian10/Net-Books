using AutoMapper;
using BookApi.Database;
using BookApi.Dtos;

namespace BookApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // * Autores
        CreateMap<Autor,AutorDto>().ReverseMap();
        CreateMap<AutorCrearDto,Autor>();
    }
}
