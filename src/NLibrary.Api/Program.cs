using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using NLibrary.Persistence;
using NLibrary.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<NLibraryDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseDefaultExceptionHandler();
app.UseFastEndpoints(
    config =>
    {
        config.Endpoints.RoutePrefix = "api";
        config.Errors.GeneralErrorsField = "general";
        config.Errors.UseProblemDetails();
    });

app.Run();
