using Microsoft.EntityFrameworkCore;

namespace BookApi.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<AutorLibro> AutorLibros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(e =>
        {
            e.ToTable("autores");
            e.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Libro>(e =>
        {
            e.ToTable("libros");
            e.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Comentario>(e =>
        {
            e.ToTable("comentarios");
            e.HasKey(e => e.Id);
            e.HasOne(e => e.Libro).WithMany(e => e.Comentarios).HasForeignKey( e => e.LibroId ).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<AutorLibro>(e =>
        {
            e.ToTable("autor_libro");
            e.HasKey(e => new {e.AutorId, e.LibroId});
            e.HasOne(e => e.Libro).WithMany(e => e.AutorLibros).HasForeignKey(e => e.LibroId);
            e.HasOne(e => e.Autor).WithMany(e => e.AutorLibros).HasForeignKey(e => e.AutorId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
