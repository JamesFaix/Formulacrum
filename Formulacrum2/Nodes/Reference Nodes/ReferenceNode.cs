using System;
using System.Collections.Generic;
using System.Text;

namespace Formulacrum {

    /// <summary>
    /// Base class for formula nodes representing references.
    /// </summary>
    public abstract class ReferenceNode : Node {

        private IntNode topRow, bottomRow, leftColumn, rightColumn;

        /// <summary>
        /// Creates a new reference node.
        /// </summary>
        internal ReferenceNode()
            : base("Reference") {
        }

        /// <summary>
        /// Gets or sets the node for first row.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>Top</c>
        /// must have lower number than <c>Bottom</c>.</exception>
        public virtual IntNode Top {
            get { return topRow; }
            set {
                if (Bottom != null && value != null && value.Value > Bottom.Value)
                    throw new ArgumentOutOfRangeException(nameof(Top) + " must have lower number than " + nameof(Bottom));
                topRow = value;
            }
        }

        /// <summary>
        /// Gets or sets the node for first column.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>Left</c>
        /// must have lower number than <c>Right</c>.</exception>
        public virtual IntNode Left {
            get { return leftColumn; }
            set {
                if (Right != null && value != null && value.Value > Right.Value)
                    throw new ArgumentOutOfRangeException(nameof(Left) + " must have lower number than " + nameof(Right));
                leftColumn = value;
            }
        }

        /// <summary>
        /// Gets or sets the node for last row.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>Bottom</c>
        /// must have higher number than <c>Top</c>.</exception>
        /// <exception cref="System.InvalidOperationException"><c>Bottom</c>
        /// can only be used if <c>Top</c> is already assigned.</exception>
        public virtual IntNode Bottom {
            get { return bottomRow; }
            set {
                if (Top == null)
                    throw new InvalidOperationException(nameof(Bottom) + " can only be used if " + nameof(Top) + " is already assigned.");
                if (value != null && value.Value < Top.Value)
                    throw new ArgumentOutOfRangeException(nameof(Bottom) + " must have higher number than " + nameof(Top));
                bottomRow = value;
            }
        }

        /// <summary>
        /// Gets or sets the node for last column.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>Right</c>
        /// must have higher number than <c>Left</c>.</exception>
        /// <exception cref="System.InvalidOperationException"><c>Right</c>
        /// can only be used if <c>Left</c> is already assigned.</exception>
        public virtual IntNode Right {
            get { return rightColumn; }
            set {
                if (Left == null)
                    throw new InvalidOperationException(nameof(Right) + " can only be used if " + nameof(Left) + " is already assigned.");
                if (value != null && value.Value < Left.Value)
                    throw new ArgumentOutOfRangeException(nameof(Right) + " must have higher number than " + nameof(Left));
                rightColumn = value;
            }
        }

        /// <summary>
        /// Gets or sets the node for the worksheet.
        /// </summary>
        public SheetNode SheetName { get; set; }

        /// <summary>
        /// Gets or sets the node for the workbook.
        /// </summary>
        public BookNode BookName { get; set; }

        /// <summary>
        /// Gets collection of child nodes.
        /// </summary>
        /// <remarks>Order will be: BookName, SheetName, Top, Left, Bottom, Right.</remarks>
        public override IEnumerable<Node> Children {
            get {
                yield return BookName;
                yield return SheetName;
                yield return topRow;
                yield return leftColumn;
                yield return bottomRow;
                yield return rightColumn;
            }
        }

        /// <summary>
        /// Gets a string representing the workbook and worksheet of this reference.
        /// </summary>
        /// <remarks>If <c>SheetName</c> is <c>null</c>, result will be empty string.
        /// If <c>BookName</c> is <c>null</c>, result will be in the form "'<c>SheetName.Value</c>'!";
        /// otherwise, result will be in the form "'[<c>BookName.Value</c>]<c>SheetName.Value</c>'!".
        /// </remarks>
        public string BookAndSheetPrefix {
            get {
                var bn = BookName;
                var sn = SheetName;

                if (sn == null) { return ""; }

                var sb = new StringBuilder("'");
                if (bn != null) {
                    sb.AppendFormat("[{0}]", bn.Value);
                }
                sb.Append(sn.Value);
                sb.Append("'!");
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets a string representing the row and column coordinates of this reference.
        /// </summary>
        public string Coordinates => (topRow != null || leftColumn != null)
            ? RenderCoordinates(topRow, leftColumn, bottomRow, rightColumn)
            : "<null>";

        /// <summary>
        /// Gets a string representing the given row and column coordinate nodes.
        /// </summary>
        /// <param name="top">The node representing the first row.</param>
        /// <param name="left">The node representing the first column.</param>
        /// <param name="bottom">The node representing the last row.</param>
        /// <param name="right">The node representing the last column.</param>
        /// <returns>String representing the given row and column coordinates.</returns>
        protected abstract string RenderCoordinates(IntNode top, IntNode left, IntNode bottom, IntNode right);

        /// <summary>
        /// Gets the rendered formula.
        /// </summary>
        /// <remarks>
        /// Result will be composed of <c>BookAndSheetPrefix</c>
        /// followed by <c>Coordinates</c>.</remarks>
        /// <param name="outline">Has no effect for reference nodes.</param>
        /// <returns>Rendered formula.</returns>
        public override string Render(bool outline) => BookAndSheetPrefix + Coordinates;

        /// <summary>
        /// Sets the coordinate nodes of this instance to the given nodes, then returns this node.
        /// </summary>
        /// <param name="top">New top row node.</param>
        /// <param name="left">New left column node.</param>
        /// <param name="bottom">New bottom row node.</param>
        /// <param name="right">New right column node.</param>
        /// <returns>Reference to this node.</returns>
        public ReferenceNode SetCoordinates(IntNode top, IntNode left, IntNode bottom, IntNode right) {
            this.Top = top;
            this.Right = right;
            this.Left = left;
            this.Bottom = bottom;
            return this;
        }
    }
}
