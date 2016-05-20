using Formulacrum.Nodes;

namespace Formulacrum {

    partial class TextFactory {

        #region Conversion

        /// <summary>
        /// Returns a node representing the <c>CHAR</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>CHAR</c> returns the character specified by the code number.</remarks>
        public static FunctionNode Char() => new FunctionNode("CHAR", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>CHAR</c> function, with the given argument.
        /// </summary>
        /// <param name="number">Node representing ASCII character code.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>CHAR</c> returns the character specified by the code number.</remarks>
        public static FunctionNode Char(Node number) => Char().SetValues(number);

        /// <summary>
        /// Returns a node representing the <c>CODE</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>CODE</c> returns a numeric code for the first character in a text string.</remarks>
        public static FunctionNode Code() => new FunctionNode("CODE", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>CODE</c> function, with the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>CODE</c> returns a numeric code for the first character in a text string.</remarks>
        public static FunctionNode Code(Node text) => Code().SetValues(text);

        /// <summary>
        /// Returns a node representing the <c>FIXED</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>FIXED</c> formats a number as text with a fixed number of decimals.</remarks>
        public static FunctionNode Fixed() => new FunctionNode("FIXED", 1, 3);

        /// <summary>
        /// Returns a node representing the <c>FIXED</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="number">Node representing number to format.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>FIXED</c> formats a number as text with a fixed number of decimals.</remarks>
        public static FunctionNode Fixed(Node number) => Fixed(number, null, null);

        /// <summary>
        /// Returns a node representing the <c>FIXED</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="number">Node representing number to format.</param>
        /// <param name="decimals">Node representing number of decimal places.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>FIXED</c> formats a number as text with a fixed number of decimals.</remarks>
        public static FunctionNode Fixed(Node number, Node decimals) => Fixed(number, decimals, null);

        /// <summary>
        /// Returns a node representing the <c>FIXED</c> function, and assigns the give arguments.
        /// </summary>
        /// <param name="number">Node representing number to format.</param>
        /// <param name="decimals">Node representing number of decimal places.</param>
        /// <param name="noCommas">Node representing whether commas will be displayed or not.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>FIXED</c> formats a number as text with a fixed number of decimals.</remarks>
        public static FunctionNode Fixed(Node number, Node decimals, Node noCommas) => Fixed().SetValues(number, decimals, noCommas);

        /// <summary>
        /// Returns a node representing the <c>TEXT</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>TEXT</c> returns a numeric code for the first character in a text string.</remarks>
        public static FunctionNode Text() => new FunctionNode("TEXT", 2, 2);

        /// <summary>
        /// Returns a node representing the <c>TEXT</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="value">Node representing value to convert to text.</param>
        /// <param name="format">Node representing format string.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>TEXT</c> returns a numeric code for the first character in a text string.</remarks>
        public static FunctionNode Text(Node value, Node format) => Text().SetValues(value, format);

        /// <summary>
        /// Returns a node representing the <c>VALUE</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>VALUE</c> converts a text argument to a number.</remarks>
        public static FunctionNode Value() => new FunctionNode("VALUE", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>VALUE</c> function, with the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>VALUE</c> converts a text argument to a number.</remarks>
        public static FunctionNode Value(Node text) => Value().SetValues(text);

        #endregion

        #region Substrings
        /// <summary>
        /// Returns a node representing the <c>LEFT</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>LEFT</c> returns the leftmost characters from a text value.</remarks>
        public static FunctionNode Left() => new FunctionNode("LEFT", 1, 2);

        /// <summary>
        /// Returns a node representing the <c>LEFT</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>LEFT</c> returns the leftmost characters from a text value.</remarks>
        public static FunctionNode Left(Node text) => Left(text, null);

        /// <summary>
        /// Returns a node representing the <c>LEFT</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <param name="length">Node representing number of characters to return.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>LEFT</c> returns the leftmost characters from a text value.</remarks>
        public static FunctionNode Left(Node text, Node length) => Left().SetValues(text, length);

        /// <summary>
        /// Returns a node representing the <c>RIGHT</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>RIGHT</c> returns the rightmost characters from a text value.</remarks>
        public static FunctionNode Right() => new FunctionNode("RIGHT", 1, 2);

        /// <summary>
        /// Returns a node representing the <c>RIGHT</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>RIGHT</c> returns the rightmost characters from a text value.</remarks>
        public static FunctionNode Right(Node text) => Right(text, null);

        /// <summary>
        /// Returns a node representing the <c>RIGHT</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <param name="length">Node representing number of characters to return.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>RIGHT</c> returns the rightmost characters from a text value.</remarks>
        public static FunctionNode Right(Node text, Node length) => Right().SetValues(text, length);

        /// <summary>
        /// Returns a node representing the <c>MID</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>MID</c> returns a specific number of characters from a
        /// text string starting at the position you specify.</remarks>
        public static FunctionNode Mid() => new FunctionNode("MID", 2, 3);

        /// <summary>
        /// Returns a node representing the <c>MID</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <param name="start">Node representing index to start at.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>MID</c> returns a specific number of characters from a
        /// text string starting at the position you specify.</remarks>
        public static FunctionNode Mid(Node text, Node start) => Mid(text, start, null);

        /// <summary>
        /// Returns a node representing the <c>MID</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <param name="start">Node representing index to start at.</param>
        /// <param name="length">Node representing number of characters to return.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>MID</c> returns a specific number of characters from a
        /// text string starting at the position you specify.</remarks>
        public static FunctionNode Mid(Node text, Node start, Node length) => Mid().SetValues(text, start, length);

        #endregion

        #region Replacement

        /// <summary>
        /// Returns a node representing the <c>REPLACE</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>REPLACE</c> replaces characters within text.</remarks>
        public static FunctionNode Replace() => new FunctionNode("REPLACE", 4, 4);

        /// <summary>
        /// Returns a node representing the <c>REPLACE</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="oldText">Node representing text to modify.</param>
        /// <param name="start">Node representing index to start replacing at.</param>
        /// <param name="length">Node representing number of characters to replace.</param>
        /// <param name="newText">Node representing text to insert into <paramref name="oldText"/>.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>REPLACE</c> replaces characters within text.</remarks>
        public static FunctionNode Replace(Node oldText, Node start, Node length, Node newText) => Replace().SetValues(oldText, start, length, newText);

        /// <summary>
        /// Returns a node representing the <c>SUBSTITUTE</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>SUBSTITUTE</c> substitutes new text for old text in a text string.</remarks>
        public static FunctionNode Substitute() => new FunctionNode("SUBSTITUTE", 3, 4);

        /// <summary>
        /// Returns a node representing the <c>SUBSTITUTE</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="text">Node representing text to modify.</param>
        /// <param name="oldText">Node representing text to remove.</param>
        /// <param name="newText">Node representing text to insert.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>SUBSTITUTE</c> substitutes new text for old text in a text string.</remarks>
        public static FunctionNode Substitute(Node text, Node oldText, Node newText) => Substitute().SetValues(text, oldText, newText, null);

        /// <summary>
        /// Returns a node representing the <c>SUBSTITUTE</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="text">Node representing text to modify.</param>
        /// <param name="oldText">Node representing text to remove.</param>
        /// <param name="newText">Node representing text to insert.</param>
        /// <param name="instance">Node representing number of instance of <paramref name="oldText"/> to replace.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>SUBSTITUTE</c> substitutes new text for old text in a text string.</remarks>
        public static FunctionNode Substitute(Node text, Node oldText, Node newText, Node instance) => Substitute().SetValues(text, oldText, newText, instance);

        #endregion

        #region Capitalization

        /// <summary>
        /// Returns a node representing the <c>LOWER</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>LOWER</c> converts text to lowercase.</remarks>
        public static FunctionNode Lower() => new FunctionNode("LOWER", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>LOWER</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>LOWER</c> converts text to lowercase.</remarks>
        public static FunctionNode Lower(Node text) => Lower().SetValues(text);

        /// <summary>
        /// Returns a node representing the <c>PROPER</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>PROPER</c> capitalizes the first letter in each word of a text value.</remarks>
        public static FunctionNode Proper() => new FunctionNode("PROPER", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>LOWER</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>PROPER</c> capitalizes the first letter in each word of a text value.</remarks>
        public static FunctionNode Proper(Node text) => Proper().SetValues(text);

        /// <summary>
        /// Returns a node representing the <c>UPPER</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>UPPER</c> converts text to uppercase.</remarks>
        public static FunctionNode Upper() => new FunctionNode("UPPER", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>UPPER</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>UPPER</c> converts text to uppercase.</remarks>
        public static FunctionNode Upper(Node text) => Upper().SetValues(text);

        #endregion

        #region Whitespace
        /// <summary>
        /// Returns a node representing the <c>CLEAN</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>CLEAN</c> removes all non-printable characters from text.</remarks>
        public static FunctionNode Clean() => new FunctionNode("CLEAN", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>CLEAN</c> function.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>CLEAN</c> removes all non-printable characters from text.</remarks>
        public static FunctionNode Clean(Node text) => Clean().SetValues(text);

        /// <summary>
        /// Returns a node representing the <c>TRIM</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>TRIM</c> removes spaces from text.</remarks>
        public static FunctionNode Trim() => new FunctionNode("TRIM", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>TRIM</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>TRIM</c> removes spaces from text.</remarks>
        public static FunctionNode Trim(Node text) => Trim().SetValues(text);

        #endregion

        #region Construction
        /// <summary>
        /// Returns a node representing the <c>CONCATENATE</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>CONCATENATE</c> joins several text items into one text item.</remarks>
        public static FunctionNode Concatenate(params Node[] args) => CommonImplementation.Aggregate("CONCATENATE", args);

        /// <summary>
        /// Returns a node representing the <c>REPT</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>REPT</c> repeats text a given number of times.</remarks>
        public static FunctionNode Rept() => new FunctionNode("REPT", 2, 2);

        /// <summary>
        /// Returns a node representing the <c>REPT</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <param name="times">Node representing number of times to repeat.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>REPT</c> repeats text a given number of times.</remarks>
        public static FunctionNode Rept(Node text, Node times) => Rept().SetValues(text, times);
        #endregion

        #region Information

        /// <summary>
        /// Returns a node representing the <c>LEN</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>LEN</c> returns the number of characters in a text string.</remarks>
        public static FunctionNode Len() => new FunctionNode("LEN", 1, 1);

        /// <summary>
        /// Returns a node representing the <c>LEN</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="text">Node representing text.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>LEN</c> returns the number of characters in a text string.</remarks>
        public static FunctionNode Len(Node text) => Len().SetValues(text);

        /// <summary>
        /// Returns a node representing the <c>FIND</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>FIND</c> finds one text value within another (case-sensitive).</remarks>
        public static FunctionNode Find() => new FunctionNode("FIND", 2, 3);

        /// <summary>
        /// Returns a node representing the <c>FIND</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="findText">Node representing text to find.</param>
        /// <param name="withinText">Node representing text to look in.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>FIND</c> finds one text value within another (case-sensitive).</remarks>
        public static FunctionNode Find(Node findText, Node withinText) => Find(findText, withinText, null);

        /// <summary>
        /// Returns a node representing the <c>FIND</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="findText">Node representing text to find.</param>
        /// <param name="withinText">Node representing text to look in.</param>
        /// <param name="start">Node representing index to start at.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>FIND</c> finds one text value within another (case-sensitive).</remarks>
        public static FunctionNode Find(Node findText, Node withinText, Node start) => Find().SetValues(findText, withinText, start);

        /// <summary>
        /// Returns a node representing the <c>SEARCH</c> function.
        /// </summary>
        /// <returns>New node.</returns>
        /// <remarks><c>SEARCH</c> finds one text value within another (not case-sensitive).</remarks>
        public static FunctionNode Search() => new FunctionNode("SEARCH", 2, 3);


        /// <summary>
        /// Returns a node representing the <c>SEARCH</c> function.
        /// </summary>
        /// <param name="findText">Node representing text to look for.</param>
        /// <param name="withinText">Node representing text to look in.</param>
        /// <param name="start">Node representing index to start at.</param>
        /// <returns>New node.</returns>
        /// <remarks><c>SEARCH</c> finds one text value within another (not case-sensitive).</remarks>
        public static FunctionNode Search(Node findText, Node withinText, Node start) => Search().SetValues(findText, withinText, start) as FunctionNode;

        #endregion
    }
}
