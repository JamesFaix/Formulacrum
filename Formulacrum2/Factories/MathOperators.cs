using Formulacrum.Nodes;

namespace Formulacrum {
    partial class Math {

        /// <summary>
        /// Returns a node for addition (+).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode Add() => new BinaryOperatorNode("Add", "+");
        /// <summary>
        /// Returns a node representing addition (+), with the given arguments.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Add(Node arg1, Node arg2) =>
            Add().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a node representing subtraction (-).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode Subtract() => new BinaryOperatorNode("Subtract", "-");
        /// <summary>
        /// Returns a node representing subtraction (-), with the given arguments.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Subtract(Node arg1, Node arg2) =>
            Subtract().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a node representing multiplication (*).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode Multiply() => new BinaryOperatorNode("Multiply", "*");
        /// <summary>
        /// Returns a node representing multiplication (*), with the given arguments.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Multiply(Node arg1, Node arg2) =>
            Multiply().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a node representing division (/).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode Divide() => new BinaryOperatorNode("Divide", "/");
        /// <summary>
        /// Returns a node representing division (/), with the given arguments.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Divide(Node arg1, Node arg2) =>
            Divide().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a node representing exponentiation (^).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode Exponent() => new BinaryOperatorNode("Exponent", "^");
        /// <summary>
        /// Returns a node representing exponentiation (^), with the given arguments.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Exponent(Node arg1, Node arg2) =>
            Exponent().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a node representing negation (-).
        /// </summary>
        /// <returns>New node.</returns>
        public static UnaryOperatorNode Negate() => new UnaryOperatorNode("Negate", "-", true);
        /// <summary>
        /// Returns a node representing negation (-), with the given argument.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg">Argument.</param>
        public static UnaryOperatorNode Negate(Node arg) => Negate().SetValues(arg);

        /// <summary>
        /// Returns a node representing percent (%).
        /// </summary>
        /// <returns>New node.</returns>
        public static UnaryOperatorNode Percent() => new UnaryOperatorNode("Percent", "%", false);
        /// <summary>
        /// Returns a node representing percent (%), with the given argument.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg">Argument.</param>
        public static UnaryOperatorNode Percent(Node arg) => Percent().SetValues(arg);

    }
}
