using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlayListGenerator.Core.Internal
{
    public class WritePlayList : IWritePlayList
    {
        private readonly IMediaFiles _mediaFiles;
        private readonly string _root;

        public WritePlayList(IMediaFiles mediaFiles, string root)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
            _mediaFiles = mediaFiles ?? throw new ArgumentNullException(nameof(mediaFiles));
        }

        public List<string> Value
        {
            get
            {
                var errorList = new List<string>();
                var currentFile = string.Empty;
                var currentPath = string.Empty;

                foreach (var file in _mediaFiles.Value.OrderBy(x => x))
                {
                    try
                    {
                        currentFile = file;
                        //C:\mp3\Artist\Album\Song.mp3 => Artist | Album | Song.mp3
                        //C:\mp3\Song.mp3 => Song.mp3
                        var filePathSplit = file.Replace(_root, "").Split('\\');

                        var targetFolder = _root;
                        string fileName;
                        string innerText;

                        if (Path.HasExtension(filePathSplit[0]))
                        {
                            //Song.mp3
                            innerText = filePathSplit[0];
                            fileName = $@"{targetFolder.Replace(_root, "").Substring(0, targetFolder.Length - 1).Split('\\').Last()}.m3u";
                        }
                        else
                        {
                            targetFolder = $@"{_root}\{filePathSplit[1]}";
                            //Album\Song.mp3
                            innerText = file.Replace(targetFolder, "").Substring(1);
                            //C:\mp3\Artist
                            fileName = $@"{targetFolder.Replace(_root, "")}.m3u";
                        }

                        var path = $@"{targetFolder}\{fileName}";
                        currentPath = path;
                        File.AppendAllText(path, innerText + Environment.NewLine);
                    }
                    catch (Exception e)
                    {
                        errorList.Add(currentFile + " | " + currentPath + " | " + e.Message);
                    }
                }

                return errorList;
            }
        }
    }
}