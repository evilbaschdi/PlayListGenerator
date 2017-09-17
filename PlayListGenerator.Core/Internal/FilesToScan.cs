using System;
using System.Collections.Generic;
using System.IO;

namespace PlayListGenerator.Core.Internal
{
    public class FilesToScan : IFilesToScan
    {
        private readonly IDirectoriesToScan _directoriesToScan;

        public FilesToScan(IDirectoriesToScan directoriesToScan)
        {
            _directoriesToScan = directoriesToScan ?? throw new ArgumentNullException(nameof(directoriesToScan));
        }

        public List<string> Value
        {
            get
            {
                var filesToScan = new List<string>();

                foreach (var directory in _directoriesToScan.Value)
                {
                    filesToScan.AddRange(Directory.GetFiles(directory));
                }

                return filesToScan;
            }
        }
    }
}