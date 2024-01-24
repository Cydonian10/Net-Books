using AutoMapper;
using BookApi.Database;
using BookApi.Dtos;

namespace BookApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // * Autores
        CreateMap<Autor, AutorDto>().ReverseMap();
        CreateMap<Autor, AutorConLibrosDto>()
            .ForMember(x => x.Libros, opciones => opciones.MapFrom(MapLibrosDto));
        CreateMap<AutorCrearDto, Autor>();

        // * Libros
        CreateMap<Libro, LibroDto>();
        CreateMap<Libro,LibroConAutoresDto>()
            .ForMember(x => x.Autores, opciones => opciones.MapFrom(MapAutoresDto));

        CreateMap<LibroCrearDto,Libro>()
            .ForMember(x => x.AutorLibros,opciones => opciones.MapFrom(MapAutoresLibros) );

        // * Comentarios
        CreateMap<Comentario,ComentarioDto>();
        CreateMap<ComentarioCrearDto,Comentario>();
    }

    private List<LibroDto> MapLibrosDto(Autor autor, AutorConLibrosDto autorConLibrosDto)
    {
        var resultado = new List<LibroDto>();

        foreach(var autorLibro in autor.AutorLibros!)
        {
            resultado.Add(new LibroDto { Id = autorLibro.Libro!.Id, Titulo = autorLibro.Libro!.Titulo});
        }

        return resultado;
    }

    private List<AutorDto> MapAutoresDto(Libro libro, LibroConAutoresDto libroDto)
    {
        var resultado = new List<AutorDto>();

        foreach (var autorLibro in libro.AutorLibros!)
        {
            resultado.Add(new AutorDto { Id = autorLibro.Autor!.Id, Nombre = autorLibro.Autor!.Nombre  });
        }

        return resultado;
    }

    private List<AutorLibro> MapAutoresLibros(LibroCrearDto dto, Libro libro)
    {
        var resultado = new List<AutorLibro>();

        if(dto.AutoresIds == null) { return resultado; }

        foreach (var autorId in dto.AutoresIds)
        {
            resultado.Add(new AutorLibro() { AutorId = autorId });
        }

        return resultado;
    }
}
