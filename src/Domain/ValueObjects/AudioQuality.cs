using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects;

public class AudioQuality(int bitrate) : ValueObject
{
    public static AudioQuality From(int bitrate)
    {
        AudioQuality quality = new(bitrate);

        if (!SupportedAudioQualities.Contains(quality))
        {
            throw new UnsupportedAudioQualityException(bitrate);
        }

        return quality;
    }

    public static AudioQuality HighQuality => new(320);
    public static AudioQuality LowQuality { get; } = new(128);

    public int Bitrate { get; } = bitrate;

    public override string ToString()
    {
        return Bitrate.ToString();
    }

    public static implicit operator string(AudioQuality quality)
    {
        return quality.ToString();
    }

    public static explicit operator AudioQuality(int bitrate)
    {
        return From(bitrate);
    }

    protected static IEnumerable<AudioQuality> SupportedAudioQualities
    {
        get
        {
            yield return HighQuality;
            yield return LowQuality;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Bitrate;
    }
}