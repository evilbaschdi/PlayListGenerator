using System;
using EvilBaschdi.Core;
using EvilBaschdi.Core.Model;

namespace PlayListGenerator.Core.Internal
{
    public class SupportedMediaFileTypesFilter : CachedValue<FileListFromPathFilter>, ISupportedMediaFileTypesFilter
    {
        private readonly ISupportedFileTypes _supportedFileTypes;

        public SupportedMediaFileTypesFilter(ISupportedFileTypes supportedFileTypes)
        {
            _supportedFileTypes = supportedFileTypes ?? throw new ArgumentNullException(nameof(supportedFileTypes));
        }

        protected override FileListFromPathFilter NonCachedValue => new FileListFromPathFilter
                                                                    {
                                                                        FilterExtensionsToEqual = _supportedFileTypes.Value
                                                                    };
    }
}