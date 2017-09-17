using System;
using System.IO;

namespace PlayListGenerator.Core.Core
{
    /// <summary>
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// </summary>
        public static bool IsAccessible(this string path)
        {
            //get directory info
            var directoryInfo = new DirectoryInfo(path);
            try
            {
                //if GetDirectories works then is accessible
                directoryInfo.GetDirectories();
                return true;
            }
            catch (Exception)
            {
                //if exception is not accessible
                return false;
            }
        }
    }
}