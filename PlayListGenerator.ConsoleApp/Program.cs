using System;
using EvilBaschdi.Core.Internal;
using PlayListGenerator.Core.Internal;

namespace PlayListGenerator.ConsoleApp
{
    /// <summary>
    ///     program class
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = args[0];
            ISupportedFileTypes supportedFileTypes = new SupportedFileTypes();
            IFileListFromPath fileListFromPath = new FileListFromPath();
            ISupportedMediaFileTypesFilter supportedMediaFileTypesFilter = new SupportedMediaFileTypesFilter(supportedFileTypes);
            IPathToScan pathToScan = new PathToScan(path);
            IMediaFiles mediaFiles = new MediaFiles(supportedMediaFileTypesFilter, fileListFromPath, pathToScan);
            IWritePlayList writePlayList = new WritePlayList(mediaFiles, pathToScan);
            IExecutePlayListGeneration executePlayListGeneration = new ExecutePlayListGeneration(writePlayList);

            executePlayListGeneration.Run();
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}