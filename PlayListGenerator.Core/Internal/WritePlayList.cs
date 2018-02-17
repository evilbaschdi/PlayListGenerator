using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlayListGenerator.Core.Internal
{
    /// <inheritdoc />
    public class WritePlayList : IWritePlayList
    {
        private readonly IMediaFiles _mediaFiles;
        private readonly IPathToScan _pathToScan;


        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="mediaFiles"></param>
        /// <param name="pathToScan"></param>
        public WritePlayList(IMediaFiles mediaFiles, IPathToScan pathToScan)
        {
            _mediaFiles = mediaFiles ?? throw new ArgumentNullException(nameof(mediaFiles));
            _pathToScan = pathToScan ?? throw new ArgumentNullException(nameof(pathToScan));
        }

        public List<string> Value
        {
            get
            {
                var errorList = new List<string>();
                var currentFile = string.Empty;
                var currentPath = string.Empty;
                var root = _pathToScan.Value;

                foreach (var file in _mediaFiles.Value.OrderBy(x => x))
                {
                    try
                    {
                        currentFile = file;
                        //C:\mp3\Artist\Album\Song.mp3 => Artist | Album | Song.mp3
                        //C:\mp3\Song.mp3 => Song.mp3
                        var filePathSplit = file.Replace(root, "").Split('\\');

                        var targetFolder = root;
                        string fileName;
                        string innerText;

                        if (Path.HasExtension(filePathSplit[0]))
                        {
                            //Song.mp3
                            innerText = filePathSplit[0];
                            fileName = $@"{targetFolder.Replace(root, "").Substring(0, targetFolder.Length - 1).Split('\\').Last()}.m3u";
                        }
                        else
                        {
                            targetFolder = $@"{root}\{filePathSplit[1]}";
                            //Album\Song.mp3
                            innerText = file.Replace(targetFolder, "").Substring(1);
                            //C:\mp3\Artist
                            fileName = $@"{targetFolder.Replace(root, "")}.m3u";
                        }

                        var path = $@"{targetFolder}\{fileName}";
                        currentPath = path;
                        File.AppendAllText(path, innerText + Environment.NewLine);
                    }
                    catch (Exception e)
                    {
                        errorList.Add($"{currentFile} | {currentPath} | {e.Message}");
                    }
                }

                return errorList;
            }
        }
    }
}