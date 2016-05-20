using System;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Extension methods for Formulacrum.Node.
    /// </summary>
    public static class NodeExt {

        /// <summary>
        /// Sets the arguments of the given binary operator to the given nodes,
        /// and returns the binary operator node.
        /// </summary>
        /// <param name="arg1">First operand.</param>
        /// <param name="op">Binary operator node.</param>
        /// <param name="arg2">Second operand.</param>
        /// <returns><paramref name="op"/>, with <paramref name="arg1"/> and <paramref name="arg2"/> assigned as arguments.</returns>
        /// <remarks>This method can be used for convenience to allow nodes for binary operators to be used
        /// in infix notation in source code, rather than the default prefix notation.</remarks>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="op"/> is <c>null</c>.</exception>
        public static BinaryOperatorNode Apply(this Node arg1, BinaryOperatorNode op, Node arg2) {
            if (op == null) throw new ArgumentNullException(nameof(op));
            op.SetValues(arg1, arg2);
            return op;
        }
    }
}
