using Microsoft.EntityFrameworkCore;
using NLibrary.Persistence.Data;

const string connectionStringEnvironmentVariable = "CONNECTION_STRING";

var isSuccessful = false;

for (var i = 0; i < 5; i++)
{
    try
    {
        var connectionString = Environment.GetEnvironmentVariable(connectionStringEnvironmentVariable);

        Console.WriteLine($"Connection string: {connectionString}");
        
        var options = new DbContextOptionsBuilder<NLibraryDbContext>()
            .LogTo(Console.WriteLine)
            .UseSqlServer(connectionString)
            .Options;

        Console.WriteLine("Migrating database...");
        
        await using var context = new NLibraryDbContext(options);
        await context.Database.MigrateAsync();
        
        Console.WriteLine("Migration completed.");
        isSuccessful = true;
        break;
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception);
        await Task.Delay(5000);
    }
}

if (!isSuccessful)
{
    Console.WriteLine("Migration failed.");
    Environment.Exit(1);
}