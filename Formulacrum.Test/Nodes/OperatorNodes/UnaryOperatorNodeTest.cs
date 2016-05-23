using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class UnaryOperatorNodeTest {

        private UnaryOperatorNode Negation => new UnaryOperatorNode("Negation", "-", true);

        #region Initialize

        [Test, TestCaseSource(nameof(UnaryOperator_InitializeNullArgs) + "_Cases")]
        public void UnaryOperator_InitializeNullArgs(string name, string symbol) {
            Assert.Throws<ArgumentNullException>(() =>
                new UnaryOperatorNode(name, symbol, false));
        }

        static IEnumerable<TestCaseData> UnaryOperator_InitializeNullArgs_Cases {
            get {
                var prefix = nameof(UnaryOperator_InitializeNullArgs);

                yield return new TestCaseData(null, "+")
                    .SetName(prefix + "_NameIsNull");
                yield return new TestCaseData("Addition", null)
                    .SetName(prefix + "_SymbolIsNull");
                yield return new TestCaseData("Addition", "")
                    .SetName(prefix + "_SymbolIsEmpty");
            }
        }

        [Test, TestCaseSource(nameof(UnaryOperator_Initialize) + "_Cases")]
        public void UnaryOperator_Initialize(string name, string symbol, bool isPrefix) {
            var node = new UnaryOperatorNode(name, symbol, isPrefix);

            Assert.AreEqual(name, node.Name);
            Assert.AreEqual(symbol, node.Symbol);
            Assert.AreEqual(isPrefix, node.IsPrefix);
            CollectionAssert.AreEqual(new Node[1], node.Children);
        }

        static IEnumerable<TestCaseData> UnaryOperator_Initialize_Cases {
            get {
                var prefix = nameof(UnaryOperator_Initialize);

                yield return new TestCaseData("Negation", "-", true)
                    .SetName(prefix + "_Negation");

                yield return new TestCaseData("Percent", "%", false)
                    .SetName(prefix + "_Percent");
            }
        }

        public void UnaryOperator_SetArg() {
            var node = Negation;
            var child = new IntNode(1);
            node[0] = child;
            Assert.AreEqual(node[0], child);
        }
        
        [Test, TestCaseSource(nameof(UnaryOperator_SetInvalidArgIndexes) + "_Cases")]
        public void UnaryOperator_SetInvalidArgIndexes(int index) {
            var node = Negation;
            var child = new IntNode(1);
            Assert.Throws<IndexOutOfRangeException>(() =>
                node[index] = child);
        }

        static IEnumerable<TestCaseData> UnaryOperator_SetInvalidArgIndexes_Cases {
            get {
                var prefix = nameof(UnaryOperator_SetInvalidArgIndexes);

                yield return new TestCaseData(-1)
                    .SetName(prefix + "_Negative");
                yield return new TestCaseData(1)
                    .SetName(prefix + "_Above0");
            }
        }

        public void UnaryOperator_SetValues() {
            var node = Negation;
            var arg = new IntNode(1);
            var result = node.SetValues(arg);
            Assert.AreEqual(arg, node[0]);
            Assert.AreEqual(node, result);
        }

        #endregion

        [Test]
        public void UnaryOperator_Clone() {
            var node = Negation;
            var clone = node.Clone() as UnaryOperatorNode;

            Assert.AreEqual(node.Name, clone.Name);
            CollectionAssert.AreEqual(new Node[1], clone.Children);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

        #region Rendering
        [Test, TestCaseSource(nameof(UnaryOperator_Render) + "_Cases")]
        public string UnaryOperator_Render(string name, string symbol, bool isPrefix, int? arg, bool outline) {
            var node = new UnaryOperatorNode(name, symbol, isPrefix);
            if (arg.HasValue) node[0] = new IntNode(arg.Value);
            return node.Render(outline);
        }

        static IEnumerable<TestCaseData> UnaryOperator_Render_Cases {
            get {
                var prefix = nameof(UnaryOperator_Render);

                yield return new TestCaseData("Negation", "-", true, null, false)
                    .Returns("-NULL")
                    .SetName(prefix + "_NegationNoArgWithoutOutline");

                yield return new TestCaseData("Negation", "-", true, null, true)
                    .Returns("-NULL")
                    .SetName(prefix + "_NegationNoArgWithOutline");

                yield return new TestCaseData("Negation", "-", true, 1, false)
                    .Returns("-1")
                    .SetName(prefix + "_NegationWithArgWithoutOutline");

                yield return new TestCaseData("Percent", "%", false, 50, false)
                    .Returns("50%")
                    .SetName(prefix + "_PercentWithArgWithotuOutline");
            }

        }

        #endregion
    }
}
