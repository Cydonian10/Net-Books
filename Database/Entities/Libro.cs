﻿using BookApi.Validators;

namespace BookApi.Database;

public class Libro : IId
{
    public int Id { get; set; }

    [PrimeraLetraMayuscula]
    public string? Titulo { get; set; }
    public virtual List<Comentario>? Comentarios { get; set; }
    public List<AutorLibro>? AutorLibros { get; set; }
}
