using Formulacrum.Nodes;

namespace Formulacrum {
    partial class Math {


        /// <summary>
        /// Returns a binary operator node for addition.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode Add() => new BinaryOperatorNode("Add", "+");
        /// <summary>
        /// Returns a binary operator node for addition, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Add(Node arg1, Node arg2) =>
            Add().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for subtraction.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode Subtract() => new BinaryOperatorNode("Subtract", "-");
        /// <summary>
        /// Returns a binary operator node for subtraction, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Subtract(Node arg1, Node arg2) =>
            Subtract().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for multiplication.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode Multiply() => new BinaryOperatorNode("Multiply", "*");
        /// <summary>
        /// Returns a binary operator node for multiplication, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Multiply(Node arg1, Node arg2) =>
            Multiply().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for division.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode Divide() => new BinaryOperatorNode("Divide", "/");
        /// <summary>
        /// Returns a binary operator node for division, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Divide(Node arg1, Node arg2) =>
            Divide().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a binary operator node for exponentiation.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode Exponent() => new BinaryOperatorNode("Exponent", "^");
        /// <summary>
        /// Returns a binary operator node for exponentiation, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Exponent(Node arg1, Node arg2) =>
            Exponent().SetValues(arg1, arg2) as BinaryOperatorNode;

        /// <summary>
        /// Returns a unary operator node for negation.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static UnaryOperatorNode Negate() => new UnaryOperatorNode("Negate", "-", true);
        /// <summary>
        /// Returns a unary operator node for negation, with the given argument.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg">Argument.</param>
        public static UnaryOperatorNode Negate(Node arg) => Negate().SetValues(arg);

        /// <summary>
        /// Returns a unary operator node for percent.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static UnaryOperatorNode Percent() => new UnaryOperatorNode("Percent", "%", false);
        /// <summary>
        /// Returns a unary operator node for percent, with the given argument.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg">Argument.</param>
        public static UnaryOperatorNode Percent(Node arg) => Percent().SetValues(arg);




    }
}
