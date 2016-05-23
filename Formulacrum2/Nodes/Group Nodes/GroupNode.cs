using System;
using System.Collections.Generic;
using System.Text;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Formula node representing pair of grouping symbols.
    /// </summary>
    public class GroupNode : Node {

        private string indentSymbol = "    ";
        private readonly string openSymbol, closeSymbol;
        private readonly NodeCollection children;

        /// <summary>
        /// Creates a new group node with the given properties.
        /// </summary>
        /// <param name="name">A user-friendly name for the node.</param>
        /// <param name="openSymbol">Opening symbol.</param>
        /// <param name="closeSymbol">Closing symbol.</param>
        /// <remarks>
        /// <see cref="MinCount"/> will be 1 and <see cref="MaxCount"/> will be <see cref="NodeCollection.CountLimit"/>.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="openSymbol"/>
        /// or <paramref name="closeSymbol"/> are <c>null</c> or empty.</exception>
        public GroupNode(string name, string openSymbol, string closeSymbol)
            : this(name, openSymbol, closeSymbol, 1, NodeCollection.CountLimit) {

            if (string.IsNullOrEmpty(openSymbol)) throw new ArgumentNullException(nameof(openSymbol));
            if (string.IsNullOrEmpty(closeSymbol)) throw new ArgumentNullException(nameof(closeSymbol));
        }

        internal GroupNode(string name, string openSymbol, string closeSymbol, int minArgs, int maxArgs)
            : base(name) {
            this.openSymbol = openSymbol;
            this.closeSymbol = closeSymbol;
            this.children = new NodeCollection(minArgs, maxArgs);
        }

        /// <summary>
        /// Collection of child nodes.
        /// </summary>
        public override IEnumerable<Node> Children => children;

        /// <summary>
        /// Gets the opening symbol.
        /// </summary>
        public string OpenSymbol => openSymbol;

        /// <summary>
        /// Gets the closing symbol.
        /// </summary>
        public string CloseSymbol => closeSymbol;

        /// <summary>
        /// Symbol to user for outline indenting. Defaults to (tab).
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Value cannot be <c>null</c>.</exception>
        public string IndentSymbol {
            get { return indentSymbol; }
            set {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                indentSymbol = value;
            }
        }

        /// <summary>Gets or sets the child node at the given index.</summary>
        /// <exception cref="System.IndexOutOfRangeException">Thrown if <c>index</c> is negative or >= <c>Children.Count</c>.</exception>
        public Node this[int index] {
            get { return children[index]; }
            set { children[index] = value; }
        }

        /// <summary>
        /// Gets the current number of child nodes (including <c>null</c>s).
        /// </summary>
        public int Count => children.Count;

        /// <summary>
        /// Gets the minimum number of child nodes.
        /// </summary>
        public int MinCount => children.MinCount;

        /// <summary>
        /// Gets the maximum number of child nodes.
        /// </summary>
        public int MaxCount => children.MaxCount;

        /// <summary>
        /// Renders node as a formula, using given outline setting.
        /// </summary>
        /// <param name="outline">If <c>true</c>, formula will be rendered as an outline,
        /// with each node on a new line and each child node indented past its parent.
        /// If <c>false</c>, formula is rendered with no line breaks or indentation.</param>
        /// <returns>Node rendered as formula.</returns>
        /// <remarks>This will recursively call Render on all child nodes, and their children, etc.
        /// Result will be <see cref="OpenSymbol"/>, followed by a comma-separated list of
        /// each child rendered, followed by <see cref="CloseSymbol"/>.</remarks>
        /// <example>If <c>grp</c> is <c>new GroupNode("Paren", "(", ")").SetArgs(null, null)</c>,
        /// then <c>grp.Formula</c> returns <c>"(NULL,NULL)"</c>.
        /// </example>
        public override string Render(bool outline) {
            var sb = new StringBuilder(openSymbol);
            var nl = Environment.NewLine;
            var middle = children.Render(outline);

            if (outline) {
                sb.Append(nl);
                foreach (var line in middle.Split(nl)) {
                    sb.AppendLine(IndentSymbol + line);
                }
                sb.Append(nl);
            }

            else {
                sb.Append(middle);
            }

            sb.Append(closeSymbol);
            return sb.ToString();
        }

        /// <summary>
        /// Returns a new node with identical properties to this instance, but with no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this instance, but with no child nodes assigned.</returns>
        public override Node Clone() => new GroupNode(Name, openSymbol, closeSymbol).SetCount(children.Count);

        /// <summary>
        /// If given count is between <c>MinCount</c> and <c>MaxCount</c>,
        /// clears all child nodes and sets child count to given value,
        /// then returns this node.
        /// </summary>
        /// <param name="count">New child count.</param>
        /// <returns>Reference to this node.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if given count is
        /// negative or >= <c>Count</c>.</exception>
        /// <remarks>All elements will be <c>null</c> after calling this method.</remarks>
        public GroupNode SetCount(int count) {
            children.SetCount(count);
            return this;
        }

        /// <summary>
        /// If number of given nodes is between <c>MinCount</c> and <c>MaxCount</c>,
        /// clears all elements, sets <c>Count</c> the number of given values,
        /// sets this all child nodes to the given nodes, and returns this node.
        /// </summary>
        /// <param name="values">Elements to assign.</param>
        /// <exception cref="System.ArgumentNullException">values</exception>
        /// <exception cref="System.ArgumentException">Thrown if number of values is not between
        /// <c>MinCount</c> and <c>MaxCount</c>.</exception>
        /// <returns>Reference to this node.</returns>
        public GroupNode SetValues(params Node[] values) {
            children.SetValues(values);
            return this;
        }
    }
}
