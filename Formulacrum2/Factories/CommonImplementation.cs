using Formulacrum.Nodes;

namespace Formulacrum {

    internal static class CommonImplementation {

        /// <summary>
        /// Returns a function node with the given name that can take between 1 and
        /// <see cref="NodeCollection.CountLimit"/> arguments, and assigns the
        /// given arguments starting at the first argument index.
        /// </summary>
        /// <param name="name">Name of function.</param>
        /// <param name="args">Arguments to assign. New node will always have room for 1 to
        /// <see cref="NodeCollection.CountLimit"/> arguments, regardless of how many are assigned.</param>
        /// <returns>New function node.</returns>
        /// <remarks>New node will always have room for 1 to 30 arguments, regardless
        /// of how many are assigned.</remarks>
        public static FunctionNode Aggregate(string name, params Node[] args) {
            var f = new FunctionNode(name, 1, NodeCollection.CountLimit);
            if (args.Length > 0) f.SetValues(args);
            return f;
        }

    }
}
