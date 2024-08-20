using Api.Infrastructure;
using Application.Tags.Commands.CreateTag;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Tags.CreateTag;

public class CreateTagEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/tags/", async (
                [FromBody]
                CreateTagRequest request,
                ISender sender,
                IMapper mapper) =>
            {
                CreateTagCommand command = mapper.Map<CreateTagCommand>(request);

                Guid id = await sender.Send(command);

                CreateTagResponse response = mapper.Map<CreateTagResponse>(id);

                return Results.Created($"/tags/{response.TagId}", response);
            })
            .Validator<CreateTagRequest>();
    }
}