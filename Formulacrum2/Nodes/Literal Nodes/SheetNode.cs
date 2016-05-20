using System;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Formula node representing a worksheet reference.
    /// </summary>
    public sealed class SheetNode : LiteralNode<string> {

        /// <summary>
        /// Creates a new sheet node with the given sheet name.
        /// </summary>
        /// <param name="sheetName">Worksheet name.</param>
        /// <exception cref="System.ArgumentException"><c>!IsValidSheetName(sheetName)</c></exception>
        public SheetNode(string sheetName)
            : base(sheetName) {
            if (!IsValidName(sheetName))
                throw new ArgumentException("Invalid sheet name");
        }

        /// <summary>
        /// Determines if a given name is a valid worksheet name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns><c>true</c>, if name is valid worksheet name.</returns>
        public static bool IsValidName(string name) =>
            !string.IsNullOrEmpty(name)
                && !(name.Length > 31);
        //TODO: Add illegal chars and other checks

        /// <summary>
        /// Returns a new node with identical properties to this node.
        /// </summary>
        /// <returns>New node with identical properties to this node.</returns>
        public override Node Clone() => new SheetNode(Value);
    }
}