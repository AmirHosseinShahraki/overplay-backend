using FluentValidation;

namespace Application.Artists.Queries.GetArtistsWithPagination;

public class GetArtistsWithPaginationQueryValidator : AbstractValidator<GetArtistsWithPaginationQuery>
{
    public GetArtistsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1");
    }
}