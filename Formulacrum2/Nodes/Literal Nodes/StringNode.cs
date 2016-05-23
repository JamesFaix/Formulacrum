namespace Formulacrum.Nodes {

    /// <summary>
    /// Formula node representing a string literal.
    /// </summary>
    public class StringNode : LiteralNode<string>{

        /// <summary>
        /// Creates new string node with the given properties.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="format">Format string.
        /// (Uses same notation as <see cref="System.String.Format(string, object)"/>.)
        /// If <c>null</c>, value will be formatted with surrounding double quotes.</param>
        public StringNode(string value, string format)
			: base(value, format ?? "\"{0}\"") {
        }

        /// <summary>
        /// Creates new string node with the given properties.
        /// </summary>
        /// <param name="value">Value.</param>
        public StringNode(string value)
            : this(value, null) {
        }

        /// <summary>
        /// Returns a new node with identical properties to this node.
        /// </summary>
        /// <returns>New node with identical properties to this node.</returns>
        public override Node Clone() => new StringNode(Value, Format);
    }
}
