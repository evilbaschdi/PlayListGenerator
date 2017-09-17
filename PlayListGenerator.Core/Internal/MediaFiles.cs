using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PlayListGenerator.Core.Core;

namespace PlayListGenerator.Core.Internal
{
    public class MediaFiles : IMediaFiles
    {
        private readonly IFilesToScan _filesToScan;
        private readonly ISupportedFileTypes _supportedFileTypes;

        public MediaFiles(ISupportedFileTypes supportedFileTypes, IFilesToScan filesToScan)

        {
            _filesToScan = filesToScan ?? throw new ArgumentNullException(nameof(filesToScan));
            _supportedFileTypes = supportedFileTypes ?? throw new ArgumentNullException(nameof(supportedFileTypes));
        }

        public List<string> Value
        {
            get
            {
                var filesSupported = new ConcurrentBag<string>();
                Parallel.ForEach(_filesToScan.Value,
                    file =>
                    {
                        var fileInfo = new FileInfo(file);
                        if (fileInfo.Extension.ToLower().TrimStart('.').In(_supportedFileTypes.Value.ToArray()))
                        {
                            filesSupported.Add(file);
                        }
                    });

                return filesSupported.ToList();
            }
        }
    }
}