using FluentValidation;

namespace Application.Songs.Queries.GetSongsWithPagination;

public class GetSongsWithPaginationQueryValidator : AbstractValidator<GetSongsWithPaginationQuery>
{
    public GetSongsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("at least greater than or equal to 1");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("at least greater than or equal to 1");
    }
}