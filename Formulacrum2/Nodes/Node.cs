using System;
using System.Collections;
using System.Collections.Generic;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Base class for formula nodes.
    /// </summary>
    public abstract class Node : IFormula, IEnumerable<Node>, ICloneable, IEquatable<Node> {

        #region Static portion

        /// <summary>
        /// The string representation of <c>null</c> used by <c>Node</c>.
        /// </summary>
        public const string NullString = "NULL";

        /// <summary>
        /// Returns the rendered formula of the given node, or "NULL" if the node is <c>null</c>.
        /// </summary>
        /// <param name="node">Node to render.</param>
        /// <param name = "outline" > If <c> true </c>, formula will be rendered as an outline,
        /// with each node on a new line and each child node indented past its parent.
        /// If <c>false</c>, formula is rendered with no line breaks or indentation.</param>
        /// <returns>Rendered formula of given node, or "NULL".</returns>
        public static string Render(Node node, bool outline) =>
            (node == null) ? NullString : node.Render(outline);

        #endregion

        #region Concrete portion

        /// <summary>
        /// Creates a new node with the given name.
        /// </summary>
        /// <param name="name">Node name.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        protected Node(string name) {
            if (name == null) throw new ArgumentNullException(nameof(name));
            this.Name = name;
        }

        /// <summary>
        /// Gets the node name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Returns the rendered formula, without outline formatting.
        /// </summary>
        /// <returns>Node rendered as formula.</returns>
        public sealed override string ToString() => Render(false);

        #region IEnumerable
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Node> GetEnumerator() => Children.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator" /> that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();

        #region IEquatable

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Node other) => ReferenceEquals(this, other);

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => Equals(obj as Node);

        #endregion
        #endregion

        #region Abstract portion

        /// <summary>
        /// Gets the collection of child nodes.
        /// </summary>
        public abstract IEnumerable<Node> Children { get; }

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
        /// Returns a new node with identical properties to this instance, but with no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this instance, but with no child nodes assigned.</returns>
        public abstract Node Clone();

        #endregion
    }
}
