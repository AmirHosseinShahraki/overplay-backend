using FluentValidation;

namespace Application.Tags.Queries.GetTagsWithPaginationQuery;

public class GetTagsWithPaginationQueryValidator : AbstractValidator<GetTagsWithPaginationQuery>
{
    public GetTagsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("at least greater than or equal to 1");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("at least greater than or equal to 1");
    }
}