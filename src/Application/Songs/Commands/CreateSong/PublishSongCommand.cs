using MediatR;

namespace Application.Songs.Commands.CreateSong;

public class PublishSongCommand : IRequest<Guid>
{
}

public class PublishSongCommandHandler : IRequestHandler<PublishSongCommand, Guid>
{
    public Task<Guid> Handle(PublishSongCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Guid.NewGuid());
    }
}