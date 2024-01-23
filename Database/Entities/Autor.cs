using System.ComponentModel.DataAnnotations;

namespace BookApi.Database;

public class Autor : IId
{
  public int Id { get; set; }

  [MaxLength(120)]
  public string? Nombre { get; set; }
}
