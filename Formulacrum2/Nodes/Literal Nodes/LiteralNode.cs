using System.Collections.Generic;

namespace Formulacrum {

    /// <summary>
    /// Formula node representing a literal value.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class LiteralNode<T> : Node {

        /// <summary>
        /// Create a new literal node with the given value and format.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="format">Format string.
        /// (Uses same notation as <see cref="System.String.Format(string, object)"/>.)
        /// If <c>null</c>, the default string representation of <c>T</c> will be used.</param>
        public LiteralNode(T value, string format)
            : base("Literal") {

            this.Value = value;
            this.Format = format;
        }

        /// <summary>
        /// Create a new literal node with the given value.
        /// </summary>
        /// <param name="value">Value.</param>
        public LiteralNode(T value)
            : this(value, null) {
        }

        #region Properties

        /// <summary>
        /// Gets or sets the literal value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>Gets or sets format string.</summary>
        /// <remarks> Uses same notation as <see cref="System.String.Format(string, object)"/>.
        /// If <c>null</c>, the default string representation of <c>T</c> will be used.</remarks>
        public string Format { get; set; }

        /// <summary>
        /// Gets collection of child nodes.
        /// </summary>
        /// <remarks>For literal nodes, this will always return an empty collection.</remarks>
        public override IEnumerable<Node> Children => new Node[0];

        #endregion

        /// <summary>
        /// Gets rendered formula.
        /// </summary>
        /// <param name="outline">Has no effect on literal nodes.</param>
        /// <remarks>Result will be <see cref="Value"/>.</remarks>
        public sealed override string Render(bool outline) => string.Format(Format, Value);

        /// <summary>
        /// Returns a new node with indentical properties to this node.
        /// </summary>
        /// <returns>New node with identical properties to this node.</returns>
        public override Node Clone() => new LiteralNode<T>(Value, Format);
    }
}
