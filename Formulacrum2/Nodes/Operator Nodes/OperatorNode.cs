using System;
using System.Collections.Generic;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Base class for formula nodes representing operators.
    /// </summary>
    public abstract class OperatorNode : Node {

        private readonly Node[] children;

        internal OperatorNode(string name, string symbol, int argCount)
            : base(name) {

            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (argCount < 1)
                throw new ArgumentOutOfRangeException(nameof(argCount));

            this.Symbol = symbol;
            this.children = new Node[argCount];
        }

        /// <summary>
        /// Gets or sets the child node at the given index.
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">Thrown if <c>index</c>
        /// is negative or >= number of arguments.</exception>
        public Node this[int index] {
            get { return children[index]; }
            set { children[index] = value; }
        }

        /// <summary>
        /// Operator symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Gets collection of child nodes.
        /// </summary>
        public override IEnumerable<Node> Children => children;
    }
}
