using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Commands.CreateArtist;

public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateArtistCommandValidator(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        RuleFor(x => x.Name)
            .MustAsync(NotExist)
            .WithMessage("An artist with the same name already exists");
    }

    private async Task<bool> NotExist(string name, CancellationToken cancellationToken)
    {
        bool exists = await _dbContext.Artists.AnyAsync(a => a.Name == name, cancellationToken);
        return !exists;
    }
}