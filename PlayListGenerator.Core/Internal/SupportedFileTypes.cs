using System.Collections.Generic;

namespace PlayListGenerator.Core.Internal
{
    public class SupportedFileTypes : ISupportedFileTypes
    {
        public List<string> Value => new List<string>
                                     {
                                         "mp3",
                                         "mp4",
                                         "m4a",
                                         "wma",
                                         "flac",
                                         "ogg",
                                         "flv"
                                     };
    }
}