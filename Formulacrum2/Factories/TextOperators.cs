using Formulacrum.Nodes;

namespace Formulacrum {

    partial class TextFactory {

        /// <summary>
        /// Returns a node representing concatenation (&amp;).
        /// </summary>
        /// <returns>New node.</returns>
        public static BinaryOperatorNode Concat() => new BinaryOperatorNode("Concatenate", "&");
        /// <summary>
        /// Returns a node representing concatenation (&amp;), with the given arguments.
        /// </summary>
        /// <returns>New node.</returns>
        /// <param name="arg1">First argument.</param>
        /// <param name="arg2">Second argument.</param>
        public static BinaryOperatorNode Concat(Node arg1, Node arg2) =>
            Concat().SetValues(arg1, arg2) as BinaryOperatorNode;

    }
}
