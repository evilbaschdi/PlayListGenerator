using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PlayListGenerator.Core.Core;

namespace PlayListGenerator.Core.Internal
{
    public class DirectoriesToScan : IDirectoriesToScan
    {
        private readonly string _path;

        public DirectoriesToScan(string path)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public List<string> Value
        {
            get
            {
                var directoriesToScan = Directory.GetDirectories(_path, "*", SearchOption.AllDirectories).Where(dir => Helpers.IsAccessible(dir)).ToList();
                directoriesToScan.Add(_path);

                return directoriesToScan;
            }
        }
    }
}