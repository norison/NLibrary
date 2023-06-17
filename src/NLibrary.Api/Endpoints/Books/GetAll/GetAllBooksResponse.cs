namespace NLibrary.Api.Endpoints.Books.GetAll;

public record GetAllBooksResponse(IEnumerable<GetAllBooksResponseItem> Books);
