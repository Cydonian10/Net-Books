using Microsoft.EntityFrameworkCore;

namespace BookApi.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }

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

        base.OnModelCreating(modelBuilder);
    }
}
