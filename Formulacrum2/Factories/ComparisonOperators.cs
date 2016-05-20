using Formulacrum.Nodes;

namespace Formulacrum {

    partial class Logic {

        /// <summary>
        /// Returns a binary operator node for equality comparison.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode EqualTo() => new BinaryOperatorNode("Equal-to", "=");
        /// <summary>
        /// Returns a binary operator node for equality comparison, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode EqualTo(Node arg1, Node arg2) =>
            EqualTo().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for inequality comparison.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode NotEqual() => new BinaryOperatorNode("No-equal-to", "<>");
        /// <summary>
        /// Returns a binary operator node for inequality comparison, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode NotEqual(Node arg1, Node arg2) =>
            NotEqual().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for less-than comparison.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode LessThan() => new BinaryOperatorNode("Less-than", "<");
        /// <summary>
        /// Returns a binary operator node for less-than comparison, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode LessThan(Node arg1, Node arg2) =>
            LessThan().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for less-than-or-equal-to comparison.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode LessOrEqual() => new BinaryOperatorNode("Less-than-or-equal-to", "<=");
        /// <summary>
        /// Returns a binary operator node for less-than-or-equal-to comparison, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode LessOrEqual(Node arg1, Node arg2) =>
            LessOrEqual().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for greater-than comparison.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode GreaterThan() => new BinaryOperatorNode("Greater-than", ">");
        /// <summary>
        /// Returns a binary operator node for greater-than comparison, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode GreaterThan(Node arg1, Node arg2) =>
            GreaterThan().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for greater-than-or-equal-to comparison.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode GreaterOrEqual() => new BinaryOperatorNode("Greater-than-or-equal-to", ">=");
        /// <summary>
        /// Returns a binary operator node for greater-than-or-equal-to comparison, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode GreaterOrEqual(Node arg1, Node arg2) =>
            GreaterOrEqual().SetValues(arg1, arg2) as BinaryOperatorNode;

    }
}
