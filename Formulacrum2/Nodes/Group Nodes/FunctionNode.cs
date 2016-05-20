namespace Formulacrum.Nodes {

    /// <summary>
    /// Formula node representing a function.
    /// </summary>
    public class FunctionNode : GroupNode {

        /// <summary>
        /// Creates a new function node with the given properties.
        /// </summary>
        /// <param name="name">Function name.</param>
        /// <param name="minArgs">Minimum number of arguments.</param>
        /// <param name="maxArgs">Maximum number of arguments.</param>
        public FunctionNode(string name, int minArgs, int maxArgs)
			: base(name, name + "(", ")", minArgs, maxArgs) {
        }

        /// <summary>
        /// Returns a new node with identical properties to this instance, but with no child nodes assigned.
        /// </summary>
        /// <returns>New node with identical properties to this instance, but with no child nodes assigned.</returns>
        public override Node Clone() => new FunctionNode(Name, MinCount, MaxCount).SetCount(Count);

        /// <summary>
        /// Clears child nodes and sets child node collection to given nodes, then returns this node.
        /// </summary>
        /// <param name="values">Nodes to assign.</param>
        /// <returns>Reference to this node.</returns>
        public new FunctionNode SetValues(params Node[] values) => base.SetValues(values) as FunctionNode;


        /// <summary>
        /// Clears child nodes and sets child node collection to give size, then returns this node.
        /// </summary>
        /// <param name="count">New size.</param>
        /// <returns>Reference to this node.</returns>
        public new FunctionNode SetCount(int count) => base.SetCount(count) as FunctionNode;
    }
}
