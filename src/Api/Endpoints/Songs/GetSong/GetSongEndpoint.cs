using Api.Infrastructure;
using Application.Songs;
using Application.Songs.Queries.GetSong;
using MediatR;

namespace Api.Endpoints.Songs.GetSong;

public class GetSongEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/songs/{id:guid}", async (Guid id, ISender sender) =>
        {
            GetSongQuery query = new()
            {
                Id = id
            };

            SongDto response = await sender.Send(query);

            return Results.Ok(response);
        });
    }
}