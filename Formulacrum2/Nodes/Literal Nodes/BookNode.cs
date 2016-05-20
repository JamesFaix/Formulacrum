using System;

namespace Formulacrum.Nodes {

    /// <summary>
    /// Formula node representing a workbook reference.
    /// </summary>
    public sealed class BookNode : LiteralNode<string> {

        /// <summary>
        /// Creates a new book node with the given name.
        /// </summary>
        /// <param name="bookName">Workbook name.</param>
        /// <exception cref="System.ArgumentException"><c>!IsValidName(bookName)</c></exception>
        public BookNode(string bookName)
            : base(bookName) {
            if (!IsValidName(bookName))
                throw new ArgumentException("Invalid book name");
        }

        /// <summary>
        /// Determines if the given name is a valid workbook name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns><c>true</c>, if name is valid workbook name.</returns>
        public static bool IsValidName(string name) => !String.IsNullOrEmpty(name);

        /// <summary>
        /// Returns a new node with identical properties to this node.
        /// </summary>
        /// <returns>New node with identical properties to this node.</returns>
        public override Node Clone() => new BookNode(Value);
    }
}