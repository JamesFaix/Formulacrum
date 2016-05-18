using System.Text;

namespace Formulacrum {

    /// <summary>
    /// Formula node representing relative references.
    /// </summary>
    public sealed class RelativeReferenceNode : ReferenceNode {
        internal RelativeReferenceNode()
            : base() {
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

            if (top != null) {
                sb.Append(FormatRow(top.Value));
            }
            if (left != null) {
                sb.Append(FormatCol(left.Value));
            }
            if (bottom != null || right != null) {
                sb.Append(":");

                sb.Append(bottom != null
                  ? FormatRow(bottom.Value)
                  : FormatRow(top.Value));

                sb.Append(right != null
                  ? FormatCol(right.Value)
                  : FormatCol(left.Value));
            }
            return sb.ToString();
        }

        private static string FormatRow(int row) => FormatIndex(row, "R");
        private static string FormatCol(int col) => FormatIndex(col, "C");
        private static string FormatIndex(int index, string label) => index == 0
            ? label
            : string.Format("{0}[{1}]", label, index);

        /// <summary>
        /// Returns a new node with indentical properties to this node, but no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this node, but no child nodes assigned.</returns>
        public override Node Clone() => new RelativeReferenceNode();
    }
}
