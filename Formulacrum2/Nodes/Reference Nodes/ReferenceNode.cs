using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formulacrum.Nodes {

    //TODO: Add support for use of $ for absolute coordinates

    //TODO: Add support for named range references

    /// <summary>
    /// Base class for formula nodes representing references.
    /// </summary>
    public abstract class ReferenceNode : Node {
        
        #region Concrete Portion
        /// <summary>
        /// Creates a new reference node.
        /// </summary>
        internal ReferenceNode()
            : base("Reference") {
        }
        
        #region Properties

        /// <summary>
        /// Gets or sets the node for first row.
        /// </summary>
        public virtual IntNode Top { get; set; }

        /// <summary>
        /// Gets or sets the node for first column.
        /// </summary>
        public virtual IntNode Left { get; set; }

        /// <summary>
        /// Gets or sets the node for last row.
        /// </summary>
        public virtual IntNode Bottom { get; set; }

        /// <summary>
        /// Gets or sets the node for last column.
        /// </summary>
        public virtual IntNode Right { get; set; }
        
        /// <summary>
        /// Gets or sets the node for the worksheet.
        /// </summary>
        public SheetNode Sheet { get; set; }

        /// <summary>
        /// Gets or sets the node for the workbook.
        /// </summary>
        public BookNode Book { get; set; }
        
        /// <summary>
        /// Gets collection of child nodes.
        /// </summary>
        /// <remarks>Order will be: BookName, SheetName, Top, Left, Bottom, Right.</remarks>
        public sealed override IEnumerable<Node> Children {
            get {
                yield return Book;
                yield return Sheet;
                yield return Top;
                yield return Left;
                yield return Bottom;
                yield return Right;
            }
        }
        #endregion

        #region In-line setter methods

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
            this.Left = left;
            if (bottom != null) this.Bottom = bottom;
            if (right != null) this.Right = right;
            return this;
        }

        /// <summary>
        /// Sets the worksheet of this instance to the given sheet, then returns this node.
        /// </summary>
        /// <param name="sheet">New sheet node.</param>
        /// <returns>Reference to this node.</returns>
        public ReferenceNode SetSheet(SheetNode sheet) {
            this.Sheet = sheet;
            return this;
        }

        /// <summary>
        /// Sets the worksheet of this instance to a new sheet node with the given name, then returns this node.
        /// </summary>
        /// <param name="name">Name of new sheet node.</param>
        /// <returns>Reference to this node.</returns>
        public ReferenceNode SetSheet(string name) {
            this.Sheet = new SheetNode(name);
            return this;
        }

        /// <summary>
        /// Sets the workbook of this instance to the given workbook, then returns this node.
        /// </summary>
        /// <param name="book">New book node.</param>
        /// <returns>References to this node.</returns>
        public ReferenceNode SetBook(BookNode book) {
            this.Book = book;
            return this;
        }

        /// <summary>
        /// Sets the workbook of this instance to a new book node with the given name, then returns this node.
        /// </summary>
        /// <param name="name">Name of new book node.</param>
        /// <returns>References to this node.</returns>
        public ReferenceNode SetBook(string name) {
            this.Book = new BookNode(name);
            return this;
        }

        #endregion

        #region Rendering

        /// <summary>
        /// Gets the rendered formula.
        /// </summary>
        /// <remarks>
        /// Result will be composed of <c>BookAndSheetPrefix</c>
        /// followed by <c>Coordinates</c>.</remarks>
        /// <param name="outline">Has no effect for reference nodes.</param>
        /// <returns>Rendered formula.</returns>
        public sealed override string Render(bool outline) => BookAndSheetPrefix + Coordinates;

        /// <summary>
        /// Gets a string representing the workbook and worksheet of this reference.
        /// </summary>
        /// <remarks>If <c>SheetName</c> is <c>null</c>, result will be empty string.
        /// If <c>BookName</c> is <c>null</c>, result will be in the form "'<c>SheetName.Value</c>'!";
        /// otherwise, result will be in the form "'[<c>BookName.Value</c>]<c>SheetName.Value</c>'!".
        /// </remarks>
        public string BookAndSheetPrefix {
            get {
                var bn = Book;
                var sn = Sheet;

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
        public string Coordinates => Children.Skip(2).Any(n => n != null)
            ? RenderCoordinates(Top, Left, Bottom, Right)
            : Node.NullString;

        #endregion

        #endregion

        #region Abstract Portion

        //Clone

        /// <summary>
        /// Gets a string representing the given row and column coordinate nodes.
        /// </summary>
        /// <param name="top">The node representing the first row.</param>
        /// <param name="left">The node representing the first column.</param>
        /// <param name="bottom">The node representing the last row.</param>
        /// <param name="right">The node representing the last column.</param>
        /// <returns>String representing the given row and column coordinates.</returns>
        protected abstract string RenderCoordinates(IntNode top, IntNode left, IntNode bottom, IntNode right);
        
        #endregion
    }
}

