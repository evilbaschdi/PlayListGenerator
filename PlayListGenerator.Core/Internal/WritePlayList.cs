using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PlayListGenerator.Core.Models;

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

        /// <inheritdoc />
        public List<string> Value
        {
            get
            {
                var errorList = new List<string>();
                var fileCacheHelperList = new List<FileCacheHelper>();
                var currentFile = string.Empty;
                var currentPath = string.Empty;
                var root = _pathToScan.Value.ToLower();

                foreach (var file in _mediaFiles.Value.OrderBy(x => x.Year).ThenBy(x => x.Path).ThenBy(x => x.Track))
                {
                    try
                    {
                        currentFile = file.Path;
                        //C:\mp3\Artist\Album\Song.mp3 => Artist | Album | Song.mp3
                        //C:\mp3\Song.mp3 => Song.mp3
                        var filePathSplit = currentFile.Replace(root, "").Split('\\');

                        var targetFolder = root;
                        string fileName;
                        string innerText;

                        if (Path.HasExtension(filePathSplit[0]))
                        {
                            //Song.mp3
                            innerText = filePathSplit[0];

                            var replace = targetFolder.Replace(root, "");
                            var substring = replace.Substring(0, targetFolder.Length - 1);


                            fileName = $@"{substring.Split('\\').Last()}.m3u";
                        }
                        else
                        {
                            targetFolder = $@"{root}\{filePathSplit[1]}";
                            //Album\Song.mp3
                            innerText = currentFile.Replace(targetFolder, "").Substring(1);
                            //C:\mp3\Artist
                            fileName = $@"{targetFolder.Replace(root, "")}.m3u";
                        }

                        var path = $@"{targetFolder}\{fileName}";
                        currentPath = path;

                        if (!File.Exists(path))
                        {
                            File.AppendAllText(path, $"#EXTM3U{Environment.NewLine}");
                        }

                        File.AppendAllText(path, $"#EXTINF:{file.Duration},{file.Artist} - {file.Title}{Environment.NewLine}");
                        File.AppendAllText(path, $"{innerText}{Environment.NewLine}");
                        var fileCacheHelper = new FileCacheHelper
                                              {
                                                  PathFromRoot = Path.Combine(filePathSplit),
                                                  TargetFolderFromRoot = path,
                                                  Mp3Info = file
                                              };

                        fileCacheHelperList.Add(fileCacheHelper);
                    }
                    catch (Exception e)
                    {
                        errorList.Add($"{currentFile} | {currentPath} | {e.Message}");
                    }
                }

                foreach (var fileCacheHelper in fileCacheHelperList.OrderBy(x => x.TargetFolderFromRoot))
                {
                    var path = Path.Combine(root, "all.m3u");
                    if (!File.Exists(path))
                    {
                        File.AppendAllText(path, $"#EXTM3U{Environment.NewLine}");
                    }

                    File.AppendAllText(path, $"#EXTINF:{fileCacheHelper.Mp3Info.Duration},{fileCacheHelper.Mp3Info.Artist} - {fileCacheHelper.Mp3Info.Title}{Environment.NewLine}");
                    File.AppendAllText(path, $"{fileCacheHelper.PathFromRoot}{Environment.NewLine}");
                }


                return errorList;
            }
        }
    }
}