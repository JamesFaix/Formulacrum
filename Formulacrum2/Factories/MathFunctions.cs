using Formulacrum.Nodes;

namespace Formulacrum {
    partial class Math {

        /// <summary>
        /// Returns a function node for the <c>ABS</c> function.
        /// </summary>
        /// <returns>New function node.</returns>
        /// <remarks><c>ABS</c> returns the absolute value of a number.</remarks>
        public static FunctionNode Abs() => new FunctionNode("ABS", 1, 1);
        /// <summary>
        /// Returns a function node for the <c>ABS</c> function, and assigns the given argument.
        /// </summary>
        /// <param name="value">Node representing value.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>ABS</c> returns the absolute value of a number.</remarks>
        public static FunctionNode Abs(Node value) => Abs().SetValues(value);

        #region Rounding

        /// <summary>
        /// Returns a function node for the <c>CEILING</c> function.
        /// </summary>
        /// <returns>New function node.</returns>
        /// <remarks><c>CEILING</c> rounds a number up, to the nearest integer
        /// or to the nearest multiple of significance.</remarks>
        public static FunctionNode Ceiling() => new FunctionNode("CEILING", 2, 2);
        /// <summary>
        /// Returns a function node for the <c>CEILING</c> function.
        /// </summary>
        /// <param name="number">Node representing number to round.</param>
        /// <param name="significance">Node representing multiple of significance.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>CEILING</c> rounds a number up, to the nearest integer
        /// or to the nearest multiple of significance.</remarks>
        public static FunctionNode Ceiling(Node number, Node significance) => Ceiling().SetValues(number, significance) as FunctionNode;

        //Floor
        //Round
        //RoundDown
        //RoundUp
        //Trunc
        //Int

        #endregion

        /// <summary>
        /// Returns a function node for the <c>SUM</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>SUM</c> returns the average of its arguments.</remarks>
        public static FunctionNode Sum(params Node[] args) => CommonImplementation.Aggregate("SUM", args);

        //SumIf
        //SumIfs
        //Exp
        //Mod
        //Product
        //Quotient
        //Rand
        //RandBetween
        //Sign
    }
}
