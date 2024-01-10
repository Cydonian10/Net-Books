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
        var libros = await context.Libros.Include(x => x.Autor).ToListAsync();
        var librosDto = mapper.Map<List<LibroDto>>(libros);
        return librosDto;
    }

    [HttpGet("{id:int}", Name = "ObtnerLibro")]
    public async Task<ActionResult<LibroDto>> GetOne([FromRoute] int id)
    {
        var libroDB = await context.Libros.AsNoTracking().Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);

        if (libroDB == null) { return NotFound(); }

        var dtos = mapper.Map<LibroDto>(libroDB);

        return dtos;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] LibroCrearDto libroCrearDto)
    {
        return await Create<Libro, LibroCrearDto, LibroDto>(libroCrearDto, "ObtnerLibro");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromRoute] LibroCrearDto libroCrearDto)
    {
        return await Update<Libro, LibroCrearDto>(id, libroCrearDto);
    }

    [HttpDelete("")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        return await Delete<Libro>(id);
    }

}
