using System.Linq;

namespace PlayListGenerator.Core.Core
{
    /// <summary>
    ///     Class to provide generic extension methods
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        ///     Extension to validate if a value is contained in a provided bunch of values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }
    }
}