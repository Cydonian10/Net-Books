using AutoMapper;
using BookApi.Database;
using BookApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers;


[ApiController]
[Route("api/libros")]
public class LibrosController : CustomBaseController
{
    private readonly DataContext context;
    private readonly IMapper mapper;

    public LibrosController(DataContext context, IMapper mapper) : base(context, mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<LibroDto>>> List()
    {
        var libros = await context.Libros.ToListAsync();
        var librosDto = mapper.Map<List<LibroDto>>(libros);
        return librosDto;
    }

    [HttpGet("{id:int}", Name = "ObtnerLibro")]
    public async Task<ActionResult<LibroConAutoresDto>> GetOne([FromRoute] int id)
    {
        var libroDB = await context.Libros
                .Include(x => x.AutorLibros!) 
                .ThenInclude(x => x.Autor)
                .FirstOrDefaultAsync(x => x.Id == id);

        if (libroDB == null) { return NotFound(); }

        var dtos = mapper.Map<LibroConAutoresDto>(libroDB);

        return dtos;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] LibroCrearDto libroCrearDto)
    {
        if(libroCrearDto.AutoresIds == null)
        {
            return BadRequest("No hay autores Ids");
        }

        var autores = await context.Autores
                .Where(x => libroCrearDto.AutoresIds!.Contains(x.Id))
                .Select(x => x.Id)
                .ToListAsync();

        if (libroCrearDto.AutoresIds!.Count != autores.Count)
        {
            return BadRequest("No existe algun actors");
        }

        return await Create<Libro, LibroCrearDto, LibroDto>(libroCrearDto, "ObtnerLibro");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] LibroCrearDto libroCrearDto)
    {
        var libroDb = await context.Libros
            .Include(x => x.AutorLibros)
            .FirstOrDefaultAsync(x => x.Id == id);

        libroDb = mapper.Map(libroCrearDto,libroDb);
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")] 
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        return await Delete<Libro>(id);
    }

}
