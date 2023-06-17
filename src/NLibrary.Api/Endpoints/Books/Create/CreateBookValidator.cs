using FastEndpoints;
using FluentValidation;

namespace NLibrary.Api.Endpoints.Books.Create;

public class CreateBookValidator : Validator<CreateBookRequest>
{
    public CreateBookValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MinimumLength(1).MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(1).MaximumLength(500);
    }
}
