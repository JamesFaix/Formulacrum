using Formulacrum.Nodes;

namespace Formulacrum {

    partial class Common {
        
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
        
    }
}
