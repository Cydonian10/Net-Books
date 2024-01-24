using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos;

public class LibroCrearDto
{
    public string? Titulo { get; set; }
    public List<int>? AutoresIds { get; set; }

}
