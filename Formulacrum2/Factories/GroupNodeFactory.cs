﻿namespace Formulacrum {

    /// <summary>
    /// Factory for grouping formula nodes.
    /// </summary>
    public static class GroupNodeFactory {

        /// <summary>
        /// Returns a group node for wrapping other nodes in parentheses.
        /// </summary>
        /// <returns>Group node for wrapping other nodes in parentheses.</returns>
        public static GroupNode Group() => Group(null);

        /// <summary>
        /// Returns a group node wrapping the given nodes in parentheses.
        /// </summary>
        /// <param name="nodes">Nodes to group.</param>
        /// <returns>Group node wrapping the given nodes in parentheses.</returns>
		public static GroupNode Group(params Node[] nodes) {
            var f = new GroupNode("Group", "(", ")");
            if (nodes != null && nodes.Length > 0) f.SetValues(nodes);
            return f;
        }

        /// <summary>
        /// Returns a group node for wrapping other nodes in an array (with curly braces).
        /// </summary>
        /// <returns>Group node for wrapping other nodes in an array.</returns>
        public static GroupNode Array() => Array(null);

        /// <summary>
        /// Returns a group node wrapping the given nodes in an array (with curly braces).
        /// </summary>
        /// <param name="nodes">Nodes to group.</param>
        /// <returns>Group node wrapping the given nodes in an array.</returns>
        public static GroupNode Array(params Node[] nodes) {
            var f = new GroupNode("Array", "{", "}");
            if (nodes != null && nodes.Length > 0) f.SetValues(nodes);
            return f;
        }

    }
}