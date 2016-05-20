using Formulacrum.Nodes;

namespace Formulacrum {

    ///<summary>Factory for relative reference formula nodes.</summary>
    public static class RelativeRefs {

        /// <summary>
        /// Returns relative reference node with unassigned coordinates.
        /// </summary>
        /// <returns>New relative reference node.</returns>
        public static ReferenceNode Empty() => new RelativeReferenceNode();

        /// <summary>
        /// Returns relative reference node with coordinates for the cell at the given row and column.
        /// </summary>
        /// <param name="row">Row number.</param>
        /// <param name="column">Column number.</param>
        /// <returns>New relative reference node.</returns>
        public static ReferenceNode Cell(IntNode row, IntNode column) =>
            new RelativeReferenceNode().SetCoordinates(row, column, null, null);

        /// <summary>
        /// Returns relative reference node with coordinates for the row at the give index.
        /// </summary>
        /// <param name="index">Row number.</param>
        /// <returns>New relative reference node.</returns>
        public static ReferenceNode Row(IntNode index) =>
            new RelativeReferenceNode().SetCoordinates(index, null, null, null);

        /// <summary>
        /// Returns relative reference node with coordinates for the span of rows between the two given indexes.
        /// </summary>
        /// <param name="top">First row.</param>
        /// <param name="bottom">Last row.</param>
        /// <returns>New relative reference node.</returns>
        public static ReferenceNode Rows(IntNode top, IntNode bottom) =>
            new RelativeReferenceNode().SetCoordinates(top, null, bottom, null);

        /// <summary>
        /// Returns relative reference node with coordinates for the column at the give index.
        /// </summary>
        /// <param name="index">Column number.</param>
        /// <returns>New relative reference node.</returns>
        public static ReferenceNode Column(IntNode index) =>
            new RelativeReferenceNode().SetCoordinates(null, index, null, null);

        /// <summary>
        /// Returns relative reference node with coordinates for the span of columns between the two given indexes.
        /// </summary>
        /// <param name="left">First column.</param>
        /// <param name="right">Last column.</param>
        /// <returns>New relative reference node.</returns>
        public static ReferenceNode Columns(IntNode left, IntNode right) =>
            new RelativeReferenceNode().SetCoordinates(null, left, null, right);

        /// <summary>
        /// Returns relative reference node with the given coordinates.
        /// </summary>
        /// <param name="top">First row.</param>
        /// <param name="left">First column.</param>
        /// <param name="bottom">Last row.</param>
        /// <param name="right">Last column.</param>
        /// <returns>New relative reference node.</returns>
        public static ReferenceNode Range(IntNode top, IntNode left, IntNode bottom, IntNode right) =>
            new RelativeReferenceNode().SetCoordinates(top, left, bottom, right);

        /// <summary>
        /// Returns a node containing a workbook reference.
        /// </summary>
        /// <param name="name">Workbook name.</param>
        /// <returns>Node containing workbook reference.</returns>
        public static BookNode Book(string name) => new BookNode(name);

        /// <summary>
        /// Returns a node containing a worksheet reference.
        /// </summary>
        /// <param name="name">Worksheet name.</param>
        /// <returns>Node containing worksheet reference.</returns>
        public static SheetNode Sheet(string name) => new SheetNode(name);
    }
}

