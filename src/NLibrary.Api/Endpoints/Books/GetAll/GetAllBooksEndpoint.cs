using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using NLibrary.Persistence.Data;

namespace NLibrary.Api.Endpoints.Books.GetAll;

public class GetAllBooksEndpoint : EndpointWithoutRequest<GetAllBooksResponse>
{
    private readonly INLibraryDbContext _dbContext;

    public GetAllBooksEndpoint(INLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var books = await _dbContext.Books
            .AsNoTracking()
            .Select(x => new GetAllBooksResponseItem(x.Id, x.Title, x.Description))
            .ToListAsync(ct);

        await SendOkAsync(new GetAllBooksResponse(books), ct);
    }
}
