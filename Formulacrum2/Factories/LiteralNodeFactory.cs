namespace Formulacrum {

    /// <summary>
    /// Factory for literal formula nodes.
    /// </summary>
    public static class LiteralNodeFactory {

        /// <summary>
        /// Returns a node containing a string literal.
        /// </summary>
        /// <param name="value">String literal.</param>
        /// <returns>Node containing string literal.</returns>
        public static StringNode String(string value) => new StringNode(value);

        /// <summary>
        /// Returns a node containing an integer literal.
        /// </summary>
        /// <param name="value">Integer literal.</param>
        /// <returns>Node containing integer literal.</returns>
        public static IntNode Int(int value) => new IntNode(value);

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

        /// <summary>
        /// Returns a node containing a decimal literal.
        /// </summary>
        /// <param name="value">Decimal literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>Node containing decimal literal.</returns>
        public static LiteralNode<decimal> Decimal(decimal value, string format) =>
            new LiteralNode<decimal>(value, format);

        /// <summary>
        /// Returns a node containing a floating-point literal.
        /// </summary>
        /// <param name="value">Floating-point literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>Node containing floating-point literal.</returns>
        public static LiteralNode<double> Double(double value, string format) =>
            new LiteralNode<double>(value, format);

        /// <summary>
        /// Returns a node containing a boolean literal.
        /// </summary>
        /// <param name="value">Boolean literal.</param>
        /// <returns>Node containing boolean literal.</returns>
        public static LiteralNode<bool> Bool(bool value) =>
            new LiteralNode<bool>(value, value.ToString().ToUpperInvariant());
    }
}