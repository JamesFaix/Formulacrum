using System;
using System.Text;

namespace Formulacrum {

    /// <summary>
    /// Formula node representing an operator with two arguments.
    /// </summary>
    public sealed class BinaryOperatorNode : OperatorNode {

        /// <summary>
        /// Creates a new instance with the given properties.
        /// </summary>
        /// <param name="name">Operator name.</param>
        /// <param name="symbol">Operator symbol.</param>
        public BinaryOperatorNode(string name, string symbol)
            : base(name, symbol, 2) {
        }

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
            var sb = new StringBuilder();
            var nl = Environment.NewLine;

            sb.Append(Render(this[0], outline));
            if (outline) sb.Append(nl);
            sb.Append(Symbol);
            if (outline) sb.Append(nl);
            sb.Append(Render(this[1], outline));

            return sb.ToString();
        }

        /// <summary>
        /// Returns a new node with identical properties to this instance, but with no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this instance, but with no child nodes assigned.</returns>
        public override Node Clone() => new BinaryOperatorNode(Name, Symbol);

        /// <summary>Sets the arguments to the given nodes, and returns this node.</summary>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        /// <returns>Reference to this node.</returns>
        public BinaryOperatorNode SetArgs(Node arg1, Node arg2) {
            this[0] = arg1;
            this[1] = arg2;
            return this;
        }
    }
}
