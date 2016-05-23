using System.Text;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Formula node representing relative references.
    /// </summary>
    public sealed class R1C1ReferenceNode : ReferenceNode {
        internal R1C1ReferenceNode()
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

            bool hasTop = top != null,
                hasBottom = bottom != null,
                hasLeft = left != null,
                hasRight = right != null;

            //Append first vertical coordinate
            if (hasTop || hasBottom)
                sb.Append(FormatRow((top ?? bottom).Value));

            //Append first horizontal coordinate
            if (hasLeft || hasRight)
                sb.Append(FormatCol((left ?? right).Value));

            //If two coordinates in either dimension, add colon
            if ((hasTop && hasBottom) || (hasLeft && hasRight)) {
                sb.Append(":");

                //Add second vertical coordinate
                if (hasTop && hasBottom) {
                    sb.Append(FormatRow(bottom.Value));
                }
                else if (hasTop || hasBottom) {
                    sb.Append(FormatRow((top ?? bottom).Value));
                }

                //Add second horizontal coordinate
                if (hasLeft && hasRight) {
                    sb.Append(FormatCol(right.Value));
                }
                else if (hasLeft || hasRight) {
                    sb.Append(FormatCol((left ?? right).Value));
                }
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
        public override Node Clone() => new R1C1ReferenceNode();
    }
}
