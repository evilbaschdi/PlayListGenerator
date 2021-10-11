using System;
using EvilBaschdi.Core;
using EvilBaschdi.Core.Model;

namespace PlayListGenerator.Core.Internal
{
    /// <inheritdoc cref="CachedValue{T}" />
    /// <inheritdoc cref="ISupportedMediaFileTypesFilter" />
    public class SupportedMediaFileTypesFilter : CachedValue<FileListFromPathFilter>, ISupportedMediaFileTypesFilter
    {
        private readonly ISupportedFileTypes _supportedFileTypes;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="supportedFileTypes"></param>
        public SupportedMediaFileTypesFilter(ISupportedFileTypes supportedFileTypes)
        {
            _supportedFileTypes = supportedFileTypes ?? throw new ArgumentNullException(nameof(supportedFileTypes));
        }

        /// <inheritdoc />
        protected override FileListFromPathFilter NonCachedValue => new()
                                                                    {
                                                                        FilterExtensionsToEqual = _supportedFileTypes.Value
                                                                    };
    }
}