using FastEndpoints;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using NLibrary.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddPersistence(builder.Configuration);

builder.Services
    .AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!);

var app = builder.Build();

app.UseHealthChecks(
    "/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.UseDefaultExceptionHandler();
app.UseFastEndpoints(
    config =>
    {
        config.Endpoints.RoutePrefix = "api";
        config.Errors.GeneralErrorsField = "general";
        config.Errors.UseProblemDetails();
    });

app.Run();
