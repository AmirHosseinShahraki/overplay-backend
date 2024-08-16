using Api.Infrastructure;
using Application.Artists.Commands.CreateArtist;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Artists.CreateArtist;

public class CreateArtistEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/artists/", async (
                [FromBody]
                CreateArtistRequest request,
                ISender sender,
                IMapper mapper,
                CancellationToken cancellationToken) =>
            {
                CreateArtistCommand command = mapper.Map<CreateArtistCommand>(request);

                Guid id = await sender.Send(command, cancellationToken);

                CreateArtistResponse response = mapper.Map<CreateArtistResponse>(id);

                return Results.Created($"/artists/{response.ArtistId}", response);
            })
            .Validator<CreateArtistRequest>()
            .DisableAntiforgery();
    }
}