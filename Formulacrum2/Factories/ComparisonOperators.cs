using Formulacrum.Nodes;

namespace Formulacrum {

    partial class Logic {

        /// <summary>
        /// Returns a node for equality comparison (=).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode EqualTo() => new BinaryOperatorNode("Equal-to", "=");
        /// <summary>
        /// Returns a node for equality comparison (=), with the given arguments.
        /// </summary>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode EqualTo(Node arg1, Node arg2) => EqualTo().SetValues(arg1, arg2);

        /// <summary>
        /// Returns a node for inequality comparison (&lt;&gt;).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode NotEqual() => new BinaryOperatorNode("No-equal-to", "<>");
        /// <summary>
        /// Returns a node for inequality comparison (&lt;&gt;), with the given arguments.
        /// </summary>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode NotEqual(Node arg1, Node arg2) => NotEqual().SetValues(arg1, arg2);

        /// <summary>
        /// Returns a node for less-than comparison (&lt;).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode LessThan() => new BinaryOperatorNode("Less-than", "<");
        /// <summary>
        /// Returns a node for less-than comparison (&lt;), with the given arguments.
        /// </summary>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode LessThan(Node arg1, Node arg2) => LessThan().SetValues(arg1, arg2);

        /// <summary>
        /// Returns a node for less-than-or-equal-to comparison (&lt;=).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode LessOrEqual() => new BinaryOperatorNode("Less-than-or-equal-to", "<=");
        /// <summary>
        /// Returns a node for less-than-or-equal-to comparison (&lt;=), with the given arguments.
        /// </summary>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode LessOrEqual(Node arg1, Node arg2) => LessOrEqual().SetValues(arg1, arg2);

        /// <summary>
        /// Returns a node for greater-than comparison (&gt;).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode GreaterThan() => new BinaryOperatorNode("Greater-than", ">");
        /// <summary>
        /// Returns a node for greater-than comparison (&gt;), with the given arguments.
        /// </summary>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode GreaterThan(Node arg1, Node arg2) => GreaterThan().SetValues(arg1, arg2);

        /// <summary>
        /// Returns a node for greater-than-or-equal-to comparison (&gt;=).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode GreaterOrEqual() => new BinaryOperatorNode("Greater-than-or-equal-to", ">=");
        /// <summary>
        /// Returns a node for greater-than-or-equal-to comparison (&gt;=), with the given arguments.
        /// </summary>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode GreaterOrEqual(Node arg1, Node arg2) => GreaterOrEqual().SetValues(arg1, arg2);

    }
}
