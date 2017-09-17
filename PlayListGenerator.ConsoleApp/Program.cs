using System;
using PlayListGenerator.Core.Internal;

namespace PlayListGenerator.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = args[0];
            ISupportedFileTypes supportedFileTypes = new SupportedFileTypes();
            IDirectoriesToScan directoriesToScan = new DirectoriesToScan(path);
            IFilesToScan filesToScan = new FilesToScan(directoriesToScan);
            IMediaFiles mediaFiles = new MediaFiles(supportedFileTypes, filesToScan);
            IWritePlayList writePlayList = new WritePlayList(mediaFiles, path);

            writePlayList.Value.ForEach(Console.WriteLine);
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}