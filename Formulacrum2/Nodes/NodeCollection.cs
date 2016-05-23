using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Resizable collection of nodes.
    /// </summary>
    public class NodeCollection : IEnumerable<Node>, IFormula {

        #region Fields
        private readonly int minCount, maxCount;
        private Node[] inner;

        ///<summary>The highest number of elements possible.</summary>
        public const int CountLimit = 30;
        #endregion

        /// <summary>
        /// Creates a new instance, with the given size limits.
        /// </summary>
        /// <param name="minCount">Starting size, and smallest size collection can be resized to.</param>
        /// <param name="maxCount">Largest size collection can be resized to.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throw if <c>minCount</c>
        /// is negative, <c>maxCount</c> is above <c>CountLimit</c>, or <c>maxCount</c>
        /// is below <c>minCount</c>.</exception>
        public NodeCollection(int minCount, int maxCount) {
            if (minCount < 0)
                throw new ArgumentOutOfRangeException(nameof(minCount) + " must be 0 or greater");
            if (maxCount < minCount)
                throw new ArgumentOutOfRangeException(nameof(maxCount) + " must be greater than or equal to " + nameof(minCount));
            if (maxCount > CountLimit)
                throw new ArgumentOutOfRangeException(nameof(maxCount) + " must be less than or equal to " + nameof(CountLimit));

            this.minCount = minCount;
            this.maxCount = maxCount;
            inner = new Node[minCount];
        }

        #region Properties

        /// <summary>
        /// Gets the smallest size the collection can be resized to.
        /// </summary>
        public int MinCount => minCount;

        /// <summary>
        /// Gets the largest size the collection can be resized to.
        /// </summary>
        public int MaxCount => maxCount;

        /// <summary>
        /// Gets the current collection size.
        /// </summary>
        public int Count => inner.Length;

        /// <summary>
        /// Gets or sets the node at the given index.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if
        /// <c>index</c> is negative or >= <c>Count</c>.</exception>
        public Node this[int index] {
            get {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException(index.ToString());
                return inner[index];
            }
            set {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException(index.ToString());
                inner[index] = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Iterates through each node.
        /// </summary>
        /// <returns>Each node.</returns>
        public IEnumerator<Node> GetEnumerator() => inner.AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// If number of given nodes is between <c>MinCount</c> and <c>MaxCount</c>,
        /// clears all elements, resizes the collection to the number of given values,
        /// and sets this collection's elements to the given nodes.
        /// </summary>
        /// <param name="values">Elements to assign.</param>
        /// <exception cref="System.ArgumentNullException">values</exception>
        /// <exception cref="System.ArgumentException">Thrown if number of values is not between
        /// <c>MinCount</c> and <c>MaxCount</c>.</exception>
        public void SetValues(params Node[] values) {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length < minCount || values.Length > maxCount)
                throw new ArgumentException("size of " + nameof(values) + " must be between " + nameof(MinCount) + " and " + nameof(MaxCount));

            inner = new Node[values.Length];
            Array.Copy(values, inner, values.Length);
        }

        /// <summary>
        /// If given count is between <c>MinCount</c> and <c>MaxCount</c>,
        /// clears all elements and resizes collection to the given count.
        /// </summary>
        /// <param name="count">New collection size.</param>
        /// <exception cref="System.ArgumentException">Thrown if number of values is not between
        /// <c>MinCount</c> and <c>MaxCount</c>.</exception>
        /// <remarks>All elements will be <c>null</c> after calling this method.</remarks>
        public void SetCount(int count) {
            if (count < minCount || count > maxCount)
                throw new ArgumentOutOfRangeException(nameof(count));
            inner = new Node[count];
        }

        /// <summary>
        /// Returns the node at the given index, cast to the given node type.
        /// </summary>
        /// <param name="index">Node index.</param>
        /// <returns>Node at given index.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Throw if <c>index</c>
        /// is negative or >= <c>Count</c>.</exception>
        /// <exception cref="System.InvalidCastException">Thrown if node at given
        /// index is not of the given type.</exception>
        public TNode GetNode<TNode>(int index)
            where TNode : Node {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(index.ToString());
            var arg = inner[index];
            if (arg == null) { return null; }
            if (!(arg is TNode)) { throw new InvalidCastException(); }
            return arg as TNode;
        }

        /// <summary>
        /// Renders nodes as a formula, using given outline setting.
        /// </summary>
        /// <param name="outline">If <c>true</c>, formula will be rendered as an outline,
        /// with each node on a new line and each child node indented past its parent.
        /// If <c>false</c>, formula is rendered with no line breaks or indentation.</param>
        /// <returns>Nodes rendered as formula.</returns>
        /// <remarks>This will recursively call Render on all child nodes, and their children, etc.</remarks>
        public string Render(bool outline) {
            var delimiter = ",";
            if (outline) delimiter += Environment.NewLine;

            return Enumerable.Range(0, Count)
                .Select(i => Node.Render(inner[i], outline))
                .ToDelimitedString(delimiter);
        }

        /// <summary>
        /// Returns the rendered formula, without outline formatting.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Render(false);

        #endregion
    }
}
