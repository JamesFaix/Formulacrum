﻿namespace Formulacrum {

    /// <summary>
    /// Factory for absolute reference formula nodes.
    /// </summary>
	public static class AbsoluteReferenceNodeFactory {

        /// <summary>
        /// Returns absolute reference node with unassigned coordinates.
        /// </summary>
        /// <returns>New absolute reference node.</returns>
        public static ReferenceNode Empty() => new AbsoluteReferenceNode();

        /// <summary>
        /// Returns absolute reference node with coordinates for the cell at the given row and column.
        /// </summary>
        /// <param name="row">Row number.</param>
        /// <param name="column">Column number.</param>
        /// <returns>New absolute reference node.</returns>
        public static ReferenceNode Cell(IntNode row, IntNode column) =>
            new AbsoluteReferenceNode().SetCoordinates(row, column, null, null);

        /// <summary>
        /// Returns absolute reference node with coordinates for the row at the give index.
        /// </summary>
        /// <param name="index">Row number.</param>
        /// <returns>New absolute reference node.</returns>
        public static ReferenceNode Row(IntNode index) =>
            new AbsoluteReferenceNode().SetCoordinates(index, null, null, null);

        /// <summary>
        /// Returns absolute reference node with coordinates for the span of rows between the two given indexes.
        /// </summary>
        /// <param name="top">First row.</param>
        /// <param name="bottom">Last row.</param>
        /// <returns>New absolute reference node.</returns>
        public static ReferenceNode Rows(IntNode top, IntNode bottom) =>
            new AbsoluteReferenceNode().SetCoordinates(top, null, bottom, null);

        /// <summary>
        /// Returns absolute reference node with coordinates for the column at the give index.
        /// </summary>
        /// <param name="index">Column number.</param>
        /// <returns>New absolute reference node.</returns>
        public static ReferenceNode Column(IntNode index) =>
            new AbsoluteReferenceNode().SetCoordinates(null, index, null, null);

        /// <summary>
        /// Returns absolute reference node with coordinates for the span of columns between the two given indexes.
        /// </summary>
        /// <param name="left">First column.</param>
        /// <param name="right">Last column.</param>
        /// <returns>New absolute reference node.</returns>
        public static ReferenceNode Columns(IntNode left, IntNode right) =>
            new AbsoluteReferenceNode().SetCoordinates(null, left, null, right);

        /// <summary>
        /// Returns absolute reference node with the given coordinates.
        /// </summary>
        /// <param name="top">First row.</param>
        /// <param name="left">First column.</param>
        /// <param name="bottom">Last row.</param>
        /// <param name="right">Last column.</param>
        /// <returns>New absolute reference node.</returns>
        public static ReferenceNode Range(IntNode top, IntNode left, IntNode bottom, IntNode right) =>
            new AbsoluteReferenceNode().SetCoordinates(top, left, bottom, right);

    }
}
