using Formulacrum.Nodes;

namespace Formulacrum {
    partial class Logic {

        #region Basic

        /// <summary>
        /// Returns a function node for the <c>NOT</c> function.
        /// </summary>
        /// <returns>New function node.</returns>
        /// <remarks><c>NOT</c> reverses the logic of its argument.</remarks>
        public static FunctionNode Not() => new FunctionNode("NOT", 1, 1);

        /// <summary>
        /// Returns a function node for the <c>NOT</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="value">Node representing value to reverse.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>NOT</c> reverses the logic of its argument.</remarks>
        public static FunctionNode Not(Node value) => Not().SetValues(value);

        /// <summary>
        /// Returns a function node for the <c>AND</c> function, with the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>AND</c> returns <c>TRUE</c> if all of its arguments are <c>TRUE</c>.</remarks>
        public static FunctionNode And(params Node[] args) => CommonImplementation.Aggregate("AND", args);

        /// <summary>
        /// Returns a function node for the <c>OR</c> function, with the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>OR</c> returns <c>TRUE</c> if any argument is <c>TRUE</c>.</remarks>
        public static FunctionNode Or(params Node[] args) => CommonImplementation.Aggregate("OR", args);

        /// <summary>
        /// Returns a function node for the <c>XOR</c> function, with the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>XOR</c> returns a logical exclusive <c>OR</c> of all arguments.
        /// This function was introduced with Excel 2013.</remarks>
        public static FunctionNode Xor(params Node[] args) => CommonImplementation.Aggregate("XOR", args);

        #endregion

        #region Conditional

        /// <summary>
        /// Returns a function node for the <c>IF</c> function.
        /// </summary>
        /// <returns>New function node.</returns>
        /// <remarks><c>IF</c> specifies a logical test to perform.</remarks>
        public static FunctionNode If() => new FunctionNode("IF", 2, 3);

        /// <summary>
        /// Returns a function node for the <c>IF</c> function, with the given test and <c>TRUE</c> value;
        /// <c>FALSE</c> value is left unassigned.
        /// </summary>
        /// <param name="test">Node representing a logical test.</param>
        /// <param name="trueValue">Node representing result if test is <c>TRUE</c>.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>IF</c> specifies a logical test to perform.</remarks>
        public static FunctionNode If(Node test, Node trueValue) => If().SetValues(test, trueValue, null) as FunctionNode;

        /// <summary>
        /// Returns a function node for the <c>IF</c> function, with the given test and <c>TRUE</c> value;
        /// <c>FALSE</c> value is left unassigned.
        /// </summary>
        /// <param name="test">Node representing a logical test.</param>
        /// <param name="trueValue">Node representing result if test is <c>TRUE</c>.</param>
        /// <param name="falseValue">Node representing result if test is <c>FALSE</c>.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>IF</c> specifies a logical test to perform.</remarks>
        public static FunctionNode If(Node test, Node trueValue, Node falseValue) => If().SetValues(test, trueValue, falseValue) as FunctionNode;

        /// <summary>
        /// Returns a function node for the <c>IFERROR</c> function.
        /// </summary>
        /// <returns>New function node.</returns>
        /// <remarks><c>IFERROR</c> returns a value you specify if a formula evaluates to an error;
        /// otherwise, returns the result of the formula.</remarks>
        public static FunctionNode IfError() => new FunctionNode("IFERROR", 2, 2);

        /// <summary>
        /// Returns a function node for the <c>IFERROR</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="value">Expression that may result in error.</param>
        /// <param name="errorValue">Expression to return if <paramref name="value"/> results in an error.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>IFERROR</c> returns a value you specify if a formula evaluates to an error;
        /// otherwise, returns the result of the formula.</remarks>
        public static FunctionNode IfError(Node value, Node errorValue) => IfError().SetValues(value, errorValue) as FunctionNode;

        #endregion
    }
}
