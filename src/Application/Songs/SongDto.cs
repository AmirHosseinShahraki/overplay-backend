using System.Text.Json.Serialization;
using Application.AudioFiles;

namespace Application.Songs;

public record SongDto : SongBriefDto
{
    [JsonPropertyOrder(6)]
    public string? Lyrics { get; init; }

    [JsonPropertyOrder(7)]
    public required HashSet<AudioFileBriefDto> Audios { get; init; }
}