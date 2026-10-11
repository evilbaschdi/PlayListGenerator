namespace PlayListGenerator.Core.Models;

/// <summary>
///     Helper class for "all.m3u" file caching
/// </summary>
public class FileCacheHelper
{
    /// <summary>
    ///     Mp3Info object;
    /// </summary>
    public Mp3Info Mp3Info { get; init; }

    /// <summary>
    ///     Path from root to file
    /// </summary>
    public string PathFromRoot { get; init; } = string.Empty;

    /// <summary>
    ///     Path to target folder from root
    /// </summary>
    public string TargetFolderFromRoot { get; init; } = string.Empty;
}