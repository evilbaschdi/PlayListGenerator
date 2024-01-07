using EvilBaschdi.Core.Extensions;
using EvilBaschdi.Core.Internal;
using PlayListGenerator.Core.Models;

namespace PlayListGenerator.Core.Internal;

/// <inheritdoc />
/// <summary>
///     Class providing a list of Mp3Info objects
/// </summary>
public class MediaFiles : IMediaFiles
{
    private readonly IFileListFromPath _filesToScan;
    private readonly IPathToScan _pathToScan;
    private readonly ISupportedMediaFileTypesFilter _supportedFileTypes;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="supportedMediaFileTypesFilter"></param>
    /// <param name="fileListFromPath"></param>
    /// <param name="pathToScan"></param>
    public MediaFiles(ISupportedMediaFileTypesFilter supportedMediaFileTypesFilter, IFileListFromPath fileListFromPath, IPathToScan pathToScan)
    {
        _filesToScan = fileListFromPath ?? throw new ArgumentNullException(nameof(fileListFromPath));
        _pathToScan = pathToScan ?? throw new ArgumentNullException(nameof(pathToScan));
        _supportedFileTypes = supportedMediaFileTypesFilter ?? throw new ArgumentNullException(nameof(supportedMediaFileTypesFilter));
    }

    /// <inheritdoc />
    public List<Mp3Info> Value
    {
        get
        {
            var files = _filesToScan.ValueFor(_pathToScan.Value.EndsWith(':') ? $"{_pathToScan.Value}\\" : _pathToScan.Value, _supportedFileTypes.Value);
            var tags = new List<Mp3Info>();

            Console.WriteLine("Reading tags...");

            foreach (var file in files)
            {
                try
                {
                    using var tagLibFile = TagLib.File.Create(file);
                    var tag = tagLibFile.Tag;
                    var properties = tagLibFile.Properties;

                    var mp3Info = new Mp3Info
                                  {
                                      Path = file.FileInfo().GetProperFilePathCapitalization(),
                                      Title = tag.Title,
                                      Artist = tag.FirstPerformer,
                                      Duration = Convert.ToInt32(Math.Round(properties.Duration.TotalSeconds)),
                                      Track = tag.Track,
                                      Year = tag.Year.Equals(0) ? 3000 : tag.Year,
                                      AlbumSort = tag.AlbumSort
                                  };

                    tags.Add(mp3Info);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{file}: {e.Message}");
                }
            }

            Console.WriteLine("Finished reading tags...");
            return tags;
        }
    }
}