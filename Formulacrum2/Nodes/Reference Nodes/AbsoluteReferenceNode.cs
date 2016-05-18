using System;
using System.Linq;
using System.Text;

namespace Formulacrum {

    /// <summary>
    /// Formula node representing a reference with absolute coordinates.
    /// </summary>
    public sealed class AbsoluteReferenceNode : ReferenceNode {

        /// <summary>
        /// Creates a new absolute reference node.
        /// </summary>
        internal AbsoluteReferenceNode()
            : base() {
        }

        /// <summary>
        /// Gets or sets the node for first row.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>Top</c>
        /// must have number greater than 0 and lower than <c>Bottom</c>.</exception>
        public override IntNode Top {
            get { return base.Top; }
            set {
                if (value != null && value.Value < 1) throw new ArgumentOutOfRangeException(nameof(value));
                base.Top = value;
            }
        }

        /// <summary>
        /// Gets or sets the node for first column.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>Left</c>
        /// must have number greater than 0 and lower than <c>Right</c>.</exception>
        public override IntNode Left {
            get { return base.Left; }
            set {
                if (value != null && value.Value < 1) throw new ArgumentOutOfRangeException(nameof(value));
                base.Left = value;
            }
        }

        /// <summary>
        /// Gets a string representing the given row and column coordinate nodes.
        /// </summary>
        /// <param name="top">The node representing the first row.</param>
        /// <param name="left">The node representing the first column.</param>
        /// <param name="bottom">The node representing the last row.</param>
        /// <param name="right">The node representing the last column.</param>
        /// <returns>String representing the given row and column coordinates.</returns>
        protected override string RenderCoordinates(IntNode top, IntNode left, IntNode bottom, IntNode right) {
            var sb = new StringBuilder();

            if (left != null) {
                sb.Append(ColumnNumberToLetters(left.Value));
            }
            if (top != null) {
                sb.Append(top.Value);
            }
            if (bottom != null || right != null) {
                sb.Append(":");

                sb.Append(right != null
                    ? ColumnNumberToLetters(right.Value)
                    : ColumnNumberToLetters(left.Value));

                sb.Append(bottom != null
                    ? bottom.Value
                       : top.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns the given number converted to column letters for absolute coordinates,
        /// or empty string if given number is less than 1.
        /// </summary>
        /// <param name="columnNumber">Column number.</param>
        /// <returns>Column letters derived from <paramref name="columnNumber"/>.</returns>
        /// <example><c>ColumnNumberToLetters(0)</c> returns ""</example>
        /// <example><c>ColumnNumberToLetters(1)</c> returns "A"</example>
        /// <example><c>ColumnNumberToLetters(26)</c> returns "Z"</example>
        /// <example><c>ColumnNumberToLetters(27)</c> returns "AA"</example>
        /// <example><c>ColumnNumberToLetters(16384)</c> returns "XFD"</example>
        public static string ColumnNumberToLetters(int columnNumber) {
            var sb = new StringBuilder();
            while (columnNumber > 0) {
                var quotient = ((columnNumber - 1) % 26) + 1;
                sb.Append(NumberToLetter(quotient));
                columnNumber = (columnNumber - quotient + 1) / 26;
            }
            return new string(sb.ToString().Reverse().ToArray());
        }

        private static string NumberToLetter(int n) {
            //Check if number corresponds to letter
            if (1 <= n && n <= 26) {
                //Start at Unicode point before 'A' and count up
                var c = (char)('A' - 1 + n);
                return c.ToString();
            }
            else {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns a new node with indentical properties to this node, but no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this node, but no child nodes assigned.</returns>
        public override Node Clone() => new AbsoluteReferenceNode();
    }
}
