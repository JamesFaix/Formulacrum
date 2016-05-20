using Formulacrum.Nodes;

namespace Formulacrum {
    partial class Math {

        #region Average
        /// <summary>
        /// Returns a function node for the <c>AVERAGE</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>AVERAGE</c> returns the average of its arguments.</remarks>
        public static FunctionNode Average(params Node[] args) => CommonImplementation.Aggregate("AVERAGE", args);

        //AverageIf
        //AverageIfs
        #endregion

        #region Count
        /// <summary>
        /// Returns a function node for the <c>COUNT</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>COUNT</c> counts how many numbers are in the list of arguments.</remarks>
        public static FunctionNode Count(params Node[] args) => CommonImplementation.Aggregate("COUNT", args);

        /// <summary>
        /// Returns a function node for the <c>COUNTA</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>COUNTA</c> counts how many values are in the list of arguments.</remarks>
        public static FunctionNode CountA(params Node[] args) => CommonImplementation.Aggregate("COUNTA", args);

        //CountIf
        //CountIfs
        #endregion

        /// <summary>
        /// Returns a function node for the <c>MAX</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>MAX</c> returns the maximum value in a list of arguments.</remarks>
        public static FunctionNode Max(params Node[] args) => CommonImplementation.Aggregate("MAX", args);

        /// <summary>
        /// Returns a function node for the <c>MIN</c> function, and assigns the given arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>New function node.</returns>
        /// <remarks><c>MIN</c> returns the minimum value in a list of arguments.</remarks>
        public static FunctionNode Min(params Node[] args) => CommonImplementation.Aggregate("MIN", args);
    }
}
