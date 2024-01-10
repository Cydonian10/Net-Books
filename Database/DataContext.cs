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

        base.OnModelCreating(modelBuilder);
    }
}
