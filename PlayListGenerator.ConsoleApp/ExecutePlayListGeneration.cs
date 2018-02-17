using System;
using PlayListGenerator.Core.Internal;

namespace PlayListGenerator.ConsoleApp
{
    public class ExecutePlayListGeneration : IExecutePlayListGeneration
    {
        private readonly IWritePlayList _writePlayList;

        public ExecutePlayListGeneration(IWritePlayList writePlayList)
        {
            _writePlayList = writePlayList ?? throw new ArgumentNullException(nameof(writePlayList));
        }

        public void Run()
        {
            _writePlayList.Value.ForEach(Console.WriteLine);
        }
    }
}