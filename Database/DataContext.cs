using Microsoft.EntityFrameworkCore;

namespace BookApi.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
