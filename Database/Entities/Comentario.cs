namespace BookApi.Database
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Contenido { get; set; }
        public int LibroId { get; set; }
        public virtual Libro? Libro { get; set; }
    }
}
