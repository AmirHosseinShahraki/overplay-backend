using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Tags.Commands.CreateTag;

public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateTagCommandValidator(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        RuleFor(x => x.Title)
            .MustAsync(NotExist)
            .WithMessage("A tag with the same title already exists");
    }

    private async Task<bool> NotExist(string title, CancellationToken cancellationToken)
    {
        bool exists = await _dbContext.Tags.AnyAsync(tag => tag.Title == title, cancellationToken);
        return !exists;
    }
}