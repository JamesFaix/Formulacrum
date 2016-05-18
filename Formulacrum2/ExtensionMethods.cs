using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formulacrum {

    /// <summary>
    /// Extension methods for internal convenience.
    /// </summary>
    internal static class StringExt {
        /// <summary>
        /// Returns a string composed of each string of input collection, separated by a delimiter.
        /// </summary>
        /// <param name="strings">Input collection.</param>
        /// <param name="delimiter">Delimiter.</param>
        /// <returns>String composed of each string of input collection, separated by a delimiter.</returns>
        public static string ToDelimitedString(this IEnumerable<string> strings, string delimiter) {
            if (strings == null) throw new ArgumentNullException(nameof(strings));
            if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));

            if (!strings.Any()) return "";

            var sb = new StringBuilder();
            sb.Append(strings.First());
            foreach (var str in strings.Skip(1)) {
                sb.Append(delimiter + (str ?? ""));
            }
            return sb.ToString();
        }

        public static string[] Split(this string text, string delimiter) {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));
            return text.Split(new string[] { delimiter }, StringSplitOptions.None);
        }

       
    }
}
