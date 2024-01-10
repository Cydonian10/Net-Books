using AutoMapper;
using BookApi.Database;
using BookApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers;


[ApiController]
[Route("api/autores")]
public class AutoresController : CustomBaseController
{
    private readonly DataContext context;
    private readonly IMapper mapper;

    public AutoresController(DataContext context, IMapper mapper) : base(context, mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<AutorDto>>>  List(){
        return await List<Autor,AutorDto>();
    }

    [HttpGet("{id:int}", Name = "ObtnerAutor")]
    public async Task<ActionResult<AutorDto>> GetOne([FromRoute] int id){
        return await GetOne<Autor,AutorDto>(id);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AutorCrearDto autorCrearDto ){
        return await Create<Autor, AutorCrearDto, AutorDto>(autorCrearDto,"ObtnerAutor");
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] AutorCrearDto autorCrearDto){
        return await Update<Autor,AutorCrearDto>(id,autorCrearDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id){
        return await Delete<Autor>(id);
    }
}
