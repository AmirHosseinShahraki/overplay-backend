using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Songs.Queries.GetSong;

public class GetSongQueryValidator : AbstractValidator<GetSongQuery>
{
    private readonly IApplicationDbContext _dbContext;

    public GetSongQueryValidator(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.Id)
            .MustAsync(Exists)
            .WithMessage("The song with the specified Id does not exist");
    }

    private Task<bool> Exists(Guid id, CancellationToken cancellationToken)
    {
        return _dbContext.Songs.AnyAsync(song => song.Id == id, cancellationToken);
    }
}