using AutoMapper;
using BookApi.Database;
using BookApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers
{
    [Route("api/libros/{libroId:int}/comentarios")]
    [ApiController]
    public class ComentarioController : CustomBaseController
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ComentarioController(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ComentarioDto>>> List([FromRoute] int libroId)
        {
            var libroDb = await context.Libros.AnyAsync(x => x.Id == libroId);
            if (!libroDb)
            {
                return NotFound();
            }

            var comentariosDb = await context.Comentarios.Where(x => x.LibroId == libroId).ToListAsync();
            return mapper.Map<List<ComentarioDto>>(comentariosDb);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromRoute] int libroId, [FromBody] ComentarioCrearDto comentarioCrearDto) 
        {
            var comentario = mapper.Map<Comentario>(comentarioCrearDto);
            comentario.LibroId = libroId;
            await context.AddAsync(comentario);
            await context.SaveChangesAsync();
            var comentarioDto = mapper.Map<ComentarioDto>(comentario);
            return Ok(comentarioDto);
        }
    }
}
