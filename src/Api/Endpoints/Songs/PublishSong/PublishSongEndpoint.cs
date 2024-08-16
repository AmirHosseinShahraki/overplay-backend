using Api.Infrastructure;
using Application.Songs.Commands.PublishSong;
using MapsterMapper;
using MediatR;

namespace Api.Endpoints.Songs.PublishSong;

public class PublishSongEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/songs/", async (
                [AsParameters]
                PublishSongRequest request,
                ISender sender,
                IMapper mapper,
                CancellationToken cancellationToken) =>
            {
                PublishSongCommand command = mapper.Map<PublishSongCommand>(request);

                Guid id = await sender.Send(command, cancellationToken);

                PublishSongResponse response = mapper.Map<PublishSongResponse>(id);
                return Results.Created($"/songs/{response.SongId}", response);
            })
            .Validator<PublishSongRequest>()
            .DisableAntiforgery();
    }
}