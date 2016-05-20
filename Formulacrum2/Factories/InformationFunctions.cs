using Formulacrum.Nodes;

namespace Formulacrum {
    partial class Logic {

        /// <summary>
        /// Returns new function node for the <c>ISBLANK</c> function.
        /// </summary>
        /// <returns>New function node.</returns>
        /// <remarks><c>ISBLANK</c> returns <c>TRUE</c> if the value is blank.</remarks>
        public static FunctionNode IsBlank() => new FunctionNode("ISBLANK", 1, 1);

        /// <summary>
        /// Returns new function node for the <c>ISBLANK</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="value">Node representing value to be tested.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>ISBLANK</c> returns <c>TRUE</c> if the value is blank.</remarks>
        public static FunctionNode IsBlank(Node value) => IsBlank().SetValues(value);

        /// <summary>
        /// Returns new function node for the <c>ISERROR</c> function.
        /// </summary>
        /// <returns>New function node.</returns>
        /// <remarks><c>ISERROR</c> returns <c>TRUE</c> if value is any error value.</remarks>
        public static FunctionNode IsError() => new FunctionNode("ISERROR", 1, 1);

        /// <summary>
        /// Returns new function node for the <c>ISERROR</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="value">Node representing value to be tested.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>ISERROR</c> returns <c>TRUE</c> if value is any error value.</remarks>
        public static FunctionNode IsError(Node value) => IsError().SetValues(value);
    }
}
