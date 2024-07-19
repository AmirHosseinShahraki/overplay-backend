using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Converters;

public class AudioQualityConverter() : ValueConverter<AudioQuality, int>(audioQuality => audioQuality.Bitrate,
    bitrate => AudioQuality.From(bitrate));