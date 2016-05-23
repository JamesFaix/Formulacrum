using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Extension methods for String and IEnumerable{String}.
    /// </summary>
    internal static class StringExt {

        /// <summary>
        /// Splits a string into substrings based on the given delimiter. 
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>An array whose elements contain the substrings in this string that are delimited by
        /// the given delimiter</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="text"/> or <paramref name="delimiter"/> are <c>null</c>.
        /// </exception>
        public static string[] Split(this string text, string delimiter) {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));
            return text.Split(new string[] { delimiter }, StringSplitOptions.None);
        }

        /// <summary>
        /// Returns a string composed of each string of input collection, separated by a delimiter.
        /// </summary>
        /// <param name="strings">Input collection.</param>
        /// <param name="delimiter">Delimiter.</param>
        /// <returns>String composed of each string of input collection, separated by a delimiter.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throw if <paramref name="strings"/> is <c>null</c> or contains <c>null</c>, 
        /// or <paramref name="delimiter"/> is <c> null</c>.</exception>
        public static string ToDelimitedString(this IEnumerable<string> strings, string delimiter) {
            if (strings == null) throw new ArgumentNullException(nameof(strings));
            if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));

            if (!strings.Any()) return "";

            var sb = new StringBuilder();

            var first = strings.First();
            if (first == null)
                throw new ArgumentNullException(nameof(strings));
            sb.Append(first);

            foreach (var str in strings.Skip(1)) {
                if (str == null)
                    throw new ArgumentNullException(nameof(strings));

                sb.Append(delimiter + str);
            }
            return sb.ToString();
        }
    }
}
