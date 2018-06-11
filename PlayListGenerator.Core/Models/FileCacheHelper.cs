namespace PlayListGenerator.Core.Models
{
    /// <summary>
    ///     Helper class for "all.m3u" file caching
    /// </summary>
    public class FileCacheHelper
    {
        /// <summary>
        ///     Mp3Info object;
        /// </summary>
        public Mp3Info Mp3Info;

        /// <summary>
        ///     Path from root to file
        /// </summary>
        public string PathFromRoot;

        /// <summary>
        ///     Path to target folder from root
        /// </summary>
        public string TargetFolderFromRoot;
    }
}