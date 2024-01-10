using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos;

public class LibroCrearDto
{
  public string? Titulo { get; set; }

  [Required]
  public int AutorId { get; set; }
}
