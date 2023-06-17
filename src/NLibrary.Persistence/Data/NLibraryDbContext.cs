using Microsoft.EntityFrameworkCore;
using NLibrary.Persistence.Entities;

namespace NLibrary.Persistence.Data;

public class NLibraryDbContext : DbContext, INLibraryDbContext
{
    public NLibraryDbContext(DbContextOptions<NLibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NLibraryDbContext).Assembly);
    }
}
