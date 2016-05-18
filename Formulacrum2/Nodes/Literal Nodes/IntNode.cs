namespace Formulacrum {

    /// <summary>
    /// Formula node representing an integer literal.
    /// </summary>
    public sealed class IntNode : LiteralNode<int>{

        /// <summary>
        /// Creates a new integer node with the given properties.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="format">Format string.
        /// (Uses same notation as <see cref="System.String.Format(string, object)"/>.)
        /// If <c>null</c>, the default string representation of <c>T</c> will be used.</param>
        public IntNode(int value, string format)
			: base(value, format){
        }

        /// <summary>
        /// Creates a new integer node with the given properties.
        /// </summary>
        /// <param name="value">Value.</param>
        public IntNode(int value)
            : this(value, null) {
        }

        /// <summary>
        /// Returns a new node with identical properties to this node.
        /// </summary>
        /// <returns>New node with identical properties to this node.</returns>
        public override Node Clone() => new IntNode(Value, Format);
    }
}
