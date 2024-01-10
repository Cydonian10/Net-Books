using BookApi.Validators;

namespace BookApi.Database;

public class Libro : IId
{
  public int Id { get; set; }

  [PrimeraLetraMayuscula]
  public string? Titulo { get; set; }
  public int AutorId { get; set; }
  public Autor? Autor { get; set; }
}
