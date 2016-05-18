using System;
using System.Collections.Generic;

namespace Formulacrum {

    /// <summary>
    /// Base class for formula nodes.
    /// </summary>
    public abstract class Node : IFormula {

        private readonly string name;

        /// <summary>
        /// Creates a new node with the given name.
        /// </summary>
        /// <param name="name">Node name.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        protected Node(string name) {
            if (name == null) throw new ArgumentNullException(nameof(name));
            this.name = name;
        }

        /// <summary>
        /// Gets the node name.
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Gets the collection of child nodes.
        /// </summary>
        public abstract IEnumerable<Node> Children { get; }

        /// <summary>
        /// Returns a new node with identical properties to this instance, but with no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this instance, but with no child nodes assigned.</returns>
        public abstract Node Clone();

        /// <summary>
        /// Renders node as a formula, using given outline setting.
        /// </summary>
        /// <param name="outline">If <c>true</c>, formula will be rendered as an outline,
        /// with each node on a new line and each child node indented past its parent.
        /// If <c>false</c>, formula is rendered with no line breaks or indentation.</param>
        /// <returns>Node rendered as formula.</returns>
        /// <remarks>This will recursively call Render on all child nodes, and their children, etc.</remarks>
        public abstract string Render(bool outline);

        /// <summary>
        /// Returns the rendered formula, without outline formatting.
        /// </summary>
        /// <returns>Node rendered as formula.</returns>
        public override string ToString() => Render(false);

        /// <summary>
        /// Returns the rendered formula of the given node, or "NULL" if the node is <c>null</c>.
        /// </summary>
        /// <param name="node">Node to render.</param>
        /// <param name = "outline" > If <c> true </c>, formula will be rendered as an outline,
        /// with each node on a new line and each child node indented past its parent.
        /// If <c>false</c>, formula is rendered with no line breaks or indentation.</param>
        /// <returns>Rendered formula of given node, or "NULL".</returns>
        public static string Render(Node node, bool outline) =>
            (node == null) ? "NULL" : node.Render(outline);
    }
}
