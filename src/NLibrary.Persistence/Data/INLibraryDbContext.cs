using Microsoft.EntityFrameworkCore;
using NLibrary.Persistence.Entities;

namespace NLibrary.Persistence.Data;

public interface INLibraryDbContext
{
    DbSet<Book> Books { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
