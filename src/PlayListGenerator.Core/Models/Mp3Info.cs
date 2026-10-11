// ReSharper disable NotAccessedField.Global

// ReSharper disable UnusedMember.Global

namespace PlayListGenerator.Core.Models;

/// <summary>
///     Mp3 info object
/// </summary>
public class Mp3Info
{
    /// <summary>
    ///     album tag
    /// </summary>
    public string Album { get; init; } = string.Empty;

    /// <summary>
    ///     album sort tag
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string AlbumSort { get; init; } = string.Empty;

    /// <summary>
    ///     artist tag
    /// </summary>
    public string Artist { get; init; } = string.Empty;

    /// <summary>
    ///     comment tag
    /// </summary>
    public string Comment { get; init; } = string.Empty;

    /// <summary>
    ///     duration property
    /// </summary>
    public int Duration { get; init; }

    /// <summary>
    ///     genre tag
    /// </summary>
    public string Genre { get; init; } = string.Empty;

    /// <summary>
    ///     path tag
    /// </summary>
    public string Path { get; init; } = string.Empty;

    /// <summary>
    ///     tag id
    /// </summary>
    public string TagId { get; init; } = string.Empty;

    /// <summary>
    ///     title tag
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    ///     track tag
    /// </summary>
    public uint Track { get; init; }

    /// <summary>
    ///     year tag
    /// </summary>
    public uint Year { get; init; }
}