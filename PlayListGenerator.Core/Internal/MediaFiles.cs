using System;
using System.Collections.Generic;
using EvilBaschdi.Core.Internal;

namespace PlayListGenerator.Core.Internal
{
    public class MediaFiles : IMediaFiles
    {
        private readonly IFileListFromPath _filesToScan;
        private readonly IPathToScan _pathToScan;
        private readonly ISupportedMediaFileTypesFilter _supportedFileTypes;

        public MediaFiles(ISupportedMediaFileTypesFilter supportedMediaFileTypesFilter, IFileListFromPath fileListFromPath, IPathToScan pathToScan)

        {
            _filesToScan = fileListFromPath ?? throw new ArgumentNullException(nameof(fileListFromPath));
            _pathToScan = pathToScan ?? throw new ArgumentNullException(nameof(pathToScan));
            _supportedFileTypes = supportedMediaFileTypesFilter ?? throw new ArgumentNullException(nameof(supportedMediaFileTypesFilter));
        }

        public List<string> Value => _filesToScan.ValueFor(_pathToScan.Value, _supportedFileTypes.Value);
    }
}