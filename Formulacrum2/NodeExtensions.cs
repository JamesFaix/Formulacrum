using System;
using Formulacrum.Nodes;

namespace Formulacrum {

    /// <summary>
    /// Extension methods for <c>Formulacrum.Nodes.Node</c>.
    /// </summary>
    public static class NodeExtensions {

        /// <summary>
        /// Assigns the given arguments to the given operator, and returns the operator.
        /// </summary>
        /// <param name="arg1">The first argument.</param>
        /// <param name="op">The operator.</param>
        /// <param name="arg2">The second argument.</param>
        /// <returns><paramref name="op"/>.</returns>
        /// <remarks>This method allows binary operators to be used with infix notation 
        /// in source code.  This makes source code expressions more closely resemble rendered formulas.</remarks>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="arg1"/> is <c>null</c>.</exception>
        public static BinaryOperatorNode Infix(this Node arg1, BinaryOperatorNode op, Node arg2) {
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            return op.SetValues(arg1, arg2);
        }
    }
}
