namespace PlayListGenerator.Core.Internal;

/// <inheritdoc />
public class SupportedFileTypes : ISupportedFileTypes
{
    /// <inheritdoc />
    public List<string> Value =>
    [
        "mp3",
        "mp4",
        "m4a",
        "wma",
        "flac",
        "ogg",
        "flv"
    ];
}