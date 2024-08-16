using MediatR;
using Application.Common.Interfaces;
using Domain.Entities;


namespace Application.Artists.Commands.CreateArtist;

public record CreateArtistCommand : IRequest<Guid>
{
    public required string Name { get; init; }
}

public class CreateArtistCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateArtistCommand, Guid>
{
    public async Task<Guid> Handle(CreateArtistCommand command, CancellationToken cancellationToken)
    {
        Artist artist = new()
        {
            Name = command.Name
        };

        dbContext.Artists.Add(artist);

        await dbContext.SaveChangesAsync(cancellationToken);

        return artist.Id;
    }
}