using FastEndpoints;
using NLibrary.Persistence.Entities;

namespace NLibrary.Api.Endpoints.Books.Create;

public class CreateBookMapper : Mapper<CreateBookRequest, CreateBookResponse, Book>
{
    public override CreateBookResponse FromEntity(Book e)
    {
        return new CreateBookResponse(e.Id);
    }

    public override Book ToEntity(CreateBookRequest r)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = r.Title,
            Description = r.Description
        };
    }
}
