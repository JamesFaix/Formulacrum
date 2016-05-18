namespace Formulacrum {

    /// <summary>
    /// Factory for operator formula nodes.
    /// </summary>
    public static class OperatorNodeFactory {

        #region Comparison
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

        #endregion

        #region Math

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

        #endregion

        #region Special
        /// <summary>
        /// Returns a unary operator node for the formula operator (=).
        /// </summary>
        /// <returns>New operator node.</returns>
        public static UnaryOperatorNode Formula() => new UnaryOperatorNode("Formula", "=", true);
        /// <summary>
        /// Returns a binary operator node for the formula operator, with the given body.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="body">Formula body</param>
        public static UnaryOperatorNode Formula(Node body) => Formula().SetValues(body);

        /// <summary>
        /// Returns a binary operator node for concatenation.
        /// </summary>
        /// <returns>New operator node.</returns>
        public static BinaryOperatorNode Concat() => new BinaryOperatorNode("Concatenate", "&");
        /// <summary>
        /// Returns a binary operator node for concatenation, with the given arguments.
        /// </summary>
        /// <returns>New operator node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Concat(Node arg1, Node arg2) =>
            Concat().SetValues(arg1, arg2) as BinaryOperatorNode;
        #endregion
    }
}
