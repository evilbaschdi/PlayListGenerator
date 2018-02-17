using System;

namespace PlayListGenerator.Core.Internal
{
    /// <inheritdoc />
    public class PathToScan : IPathToScan
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="pathToScan"></param>
        public PathToScan(string pathToScan)
        {
            Value = pathToScan ?? throw new ArgumentNullException(nameof(pathToScan));
        }

        /// <inheritdoc />
        public string Value { get; }
    }
}