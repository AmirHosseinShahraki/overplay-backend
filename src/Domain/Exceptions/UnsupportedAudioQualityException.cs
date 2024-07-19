namespace Domain.Exceptions;

public class UnsupportedAudioQualityException(int bitrate) : Exception($"Audio quality \"{bitrate}\" is unsupported.");