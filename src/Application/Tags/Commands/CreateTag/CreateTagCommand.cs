using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Tags.Commands.CreateTag;

public record CreateTagCommand : IRequest<Guid>
{
    public required string Title { get; init; }
}

public class CreateTagCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateTagCommand, Guid>
{
    public async Task<Guid> Handle(CreateTagCommand command, CancellationToken cancellationToken)
    {
        Tag tag = new()
        {
            Title = command.Title
        };

        dbContext.Tags.Add(tag);

        await dbContext.SaveChangesAsync(cancellationToken);

        return tag.Id;
    }
}