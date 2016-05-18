namespace Formulacrum {

    /// <summary>
    /// Formula node representing an operator with one argument.
    /// </summary>
    public sealed class UnaryOperatorNode : OperatorNode {

        private readonly bool isPrefix;

        /// <summary>
        /// Creates a new instance with the given properties.
        /// </summary>
        /// <param name="name">Operator name.</param>
        /// <param name="symbol">Operator symbol.</param>
        /// <param name="isPrefix">Value indicating if symbol is rendered before (<c>true</c>)
        /// or after (<c>false</c>) argument.</param>
        public UnaryOperatorNode(string name, string symbol, bool isPrefix)
            : base(name, symbol, 1) {
            this.isPrefix = isPrefix;
        }

        /// <summary>
        /// Gets a value indicating if symbol is rendered before (<c>true</c>)
        /// or after (<c>false</c>) argument.
        /// </summary>
        public bool IsPrefix => isPrefix;

        /// <summary>
        /// Renders node as a formula, using given outline setting.
        /// </summary>
        /// <param name="outline">If <c>true</c>, formula will be rendered as an outline,
        /// with each node on a new line and each child node indented past its parent.
        /// If <c>false</c>, formula is rendered with no line breaks or indentation.
        /// Defaults to <c>false</c>.</param>
        /// <returns>Node rendered as formula.</returns>
        /// <remarks>This will recursively call Render on all child nodes, and their children, etc.</remarks>
        public override string Render(bool outline) {
            var arg = Render(this[0], outline);

            return isPrefix
                ? Symbol + arg
                : arg + Symbol;
        }

        /// <summary>
        /// Returns a new node with identical properties to this instance, but with no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this instance, but with no child nodes assigned.</returns>
        public override Node Clone() => new UnaryOperatorNode(Name, Symbol, isPrefix);

        /// <summary>
        /// Sets argument to given value and returns this node.
        /// </summary>
        /// <param name="arg">Argument node.</param>
        /// <returns>Reference to this node.</returns>
        public UnaryOperatorNode SetValues(Node arg) {
            this[0] = arg;
            return this;
        }
    }
}
