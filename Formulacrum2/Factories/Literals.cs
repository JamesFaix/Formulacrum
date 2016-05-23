using Formulacrum.Nodes;

namespace Formulacrum {

    partial class Common {

        /// <summary>
        /// Returns a node representing a string literal.
        /// </summary>
        /// <param name="value">String literal.</param>
        /// <returns>New node</returns>
        public static StringNode Literal(string value) => new StringNode(value);


        /// <summary>
        /// Returns a node representing a string literal.
        /// </summary>
        /// <param name="value">String literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>New node</returns>
        public static StringNode Literal(string value, string format) => new StringNode(value, format);

        /// <summary>
        /// Returns a node representing an integer literal.
        /// </summary>
        /// <param name="value">Integer literal.</param>
        /// <returns>New node</returns>
        public static IntNode Literal(int value) => new IntNode(value, "{0}");


        /// <summary>
        /// Returns a node representing an integer literal.
        /// </summary>
        /// <param name="value">Integer literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>New node</returns>
        public static IntNode Literal(int value, string format) => new IntNode(value, format);

        /// <summary>
        /// Returns a node representing a decimal literal.
        /// </summary>
        /// <param name="value">Decimal literal.</param>
        /// <returns>New node</returns>
        public static LiteralNode<decimal> Literal(decimal value) => new LiteralNode<decimal>(value, "{0:0.00}");

        /// <summary>
        /// Returns a node representing a decimal literal.
        /// </summary>
        /// <param name="value">Decimal literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>New node</returns>
        public static LiteralNode<decimal> Literal(decimal value, string format) => new LiteralNode<decimal>(value, format);

        /// <summary>
        /// Returns a node representing a floating-point literal.
        /// </summary>
        /// <param name="value">Floating-point literal.</param>
        /// <returns>New node</returns>
        public static LiteralNode<double> Literal(double value) => new LiteralNode<double>(value, "{0:0.00}");

        /// <summary>
        /// Returns a node representing a floating-point literal.
        /// </summary>
        /// <param name="value">Floating-point literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>New node</returns>
        public static LiteralNode<double> Literal(double value, string format) => new LiteralNode<double>(value, format);

        /// <summary>
        /// Returns a node representing a boolean literal.
        /// </summary>
        /// <param name="value">Boolean literal.</param>
        /// <returns>New node</returns>
        public static LiteralNode<bool> Literal(bool value) => new LiteralNode<bool>(value, value.ToString().ToUpperInvariant());

        /// <summary>
        /// Returns a node representing a boolean literal.
        /// </summary>
        /// <param name="value">Boolean literal.</param>
        /// <param name="format">Format string.</param>
        /// <returns>New node</returns>
        public static LiteralNode<bool> Literal(bool value, string format) => new LiteralNode<bool>(value, format);

    }
}