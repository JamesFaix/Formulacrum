using Formulacrum.Nodes;

namespace Formulacrum {
    
    partial class Common {

        /// <summary>
        /// Returns a node representing a string literal.
        /// </summary>
        /// <param name="value">String literal.</param>
        /// <returns>New node</returns>
        public static StringNode String(string value) => new StringNode(value);

        /// <summary>
        /// Returns a node representing an integer literal.
        /// </summary>
        /// <param name="value">Integer literal.</param>
        /// <returns>New node</returns>
        public static IntNode Int(int value) => new IntNode(value);

        /// <summary>
        /// Returns a node representing a decimal literal.
        /// </summary>
        /// <param name="value">Decimal literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>New node</returns>
        public static LiteralNode<decimal> Decimal(decimal value, string format) =>
            new LiteralNode<decimal>(value, format);

        /// <summary>
        /// Returns a node representing a floating-point literal.
        /// </summary>
        /// <param name="value">Floating-point literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>New node</returns>
        public static LiteralNode<double> Double(double value, string format) =>
            new LiteralNode<double>(value, format);

        /// <summary>
        /// Returns a node representing a boolean literal.
        /// </summary>
        /// <param name="value">Boolean literal.</param>
        /// <returns>New node</returns>
        public static LiteralNode<bool> Bool(bool value) =>
            new LiteralNode<bool>(value, value.ToString().ToUpperInvariant());

    }
}