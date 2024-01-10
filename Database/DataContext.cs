using Microsoft.EntityFrameworkCore;

namespace BookApi.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }

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
            e.HasOne(e => e.Autor).WithMany(e => e.Libros).HasForeignKey(e => e.AutorId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
