using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos;

public class AutorCrearDto
{
  [Required]
  [MaxLength(120)]
  public string? Nombre { get; set; }
}
