using Formulacrum.Nodes;

namespace Formulacrum {

    partial class Common {

        /// <summary>
        /// Returns a node representing the formula operator (=).
        /// </summary>
        /// <returns>New node.</returns>
        public static UnaryOperatorNode Formula() => new UnaryOperatorNode("Formula", "=", true);
        /// <summary>
        /// Returns a node representing the formula operator (=), with the given body.
        /// </summary>
        /// <param name="body">Formula body</param>
        /// <returns>New node.</returns>
        public static UnaryOperatorNode Formula(Node body) => Formula().SetValues(body);
        
    }
}
