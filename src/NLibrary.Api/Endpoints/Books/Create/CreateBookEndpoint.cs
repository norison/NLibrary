using FastEndpoints;
using NLibrary.Persistence.Data;

namespace NLibrary.Api.Endpoints.Books.Create;

public class CreateBookEndpoint : Endpoint<CreateBookRequest, CreateBookResponse, CreateBookMapper>
{
    private readonly INLibraryDbContext _dbContext;

    public CreateBookEndpoint(INLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public override void Configure()
    {
        Post("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
    {
        var book = Map.ToEntity(req);

        await _dbContext.Books.AddAsync(book, ct);
        await _dbContext.SaveChangesAsync(ct);

        var response = Map.FromEntity(book);

        await SendOkAsync(response, ct);
    }
}
