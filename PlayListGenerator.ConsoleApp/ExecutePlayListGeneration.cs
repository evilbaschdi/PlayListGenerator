using PlayListGenerator.Core.Internal;

namespace PlayListGenerator.ConsoleApp;

/// <inheritdoc />
public class ExecutePlayListGeneration : IExecutePlayListGeneration
{
    private readonly IWritePlayList _writePlayList;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="writePlayList"></param>
    public ExecutePlayListGeneration(IWritePlayList writePlayList)
    {
        _writePlayList = writePlayList ?? throw new ArgumentNullException(nameof(writePlayList));
    }

    /// <inheritdoc />
    public void Run()
    {
        _writePlayList.Value.ForEach(Console.WriteLine);
    }
}