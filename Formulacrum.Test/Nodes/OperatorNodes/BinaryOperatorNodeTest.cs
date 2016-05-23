using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class BinaryOperatorNodeTest {

        private BinaryOperatorNode Addition => new BinaryOperatorNode("Addition", "+");

        #region Initialize

        [Test, TestCaseSource(nameof(BinaryOperator_InitializeNullArgs) + "_Cases")]
        public void BinaryOperator_InitializeNullArgs(string name, string symbol) {
            Assert.Throws<ArgumentNullException>(() =>
                new BinaryOperatorNode(name, symbol));
        }

        static IEnumerable<TestCaseData> BinaryOperator_InitializeNullArgs_Cases {
            get {
                var prefix = nameof(BinaryOperator_InitializeNullArgs);

                yield return new TestCaseData(null, "+")
                    .SetName(prefix + "_NameIsNull");
                yield return new TestCaseData("Addition", null)
                    .SetName(prefix + "_SymbolIsNull");
                yield return new TestCaseData("Addition", "")
                    .SetName(prefix + "_SymbolIsEmpty");
            }
        }
        
        [Test]
        public void BinaryOperator_Initialize() {
            var name = "Addition";
            var symbol = "+";

            var node = new BinaryOperatorNode(name, symbol);

            Assert.AreEqual(name, node.Name);
            Assert.AreEqual(symbol, node.Symbol);
            CollectionAssert.AreEqual(new Node[2], node.Children);
        }

        public void BinaryOperator_SetArg0() {
            var node = Addition;
            var child = new IntNode(1);
            node[0] = child;
            Assert.AreEqual(node[0], child);
        }

        public void BinaryOperator_SetArg1() {
            var node = Addition;
            var child = new IntNode(1);
            node[1] = child;
            Assert.AreEqual(node[1], child);
        }

        [Test, TestCaseSource(nameof(BinaryOperator_SetInvalidArgIndexes) + "_Cases")]
        public void BinaryOperator_SetInvalidArgIndexes(int index) {
            var node = Addition;
            var child = new IntNode(1);
            Assert.Throws<IndexOutOfRangeException>(() =>
                node[index] = child);
        }

        static IEnumerable<TestCaseData> BinaryOperator_SetInvalidArgIndexes_Cases {
            get {
                var prefix = nameof(BinaryOperator_SetInvalidArgIndexes);

                yield return new TestCaseData(-1)
                    .SetName(prefix + "_Negative");
                yield return new TestCaseData(2)
                    .SetName(prefix + "_Above1");
            }
        }

        public void BinaryOperator_SetValues() {
            var node = Addition;
            var arg1 = new IntNode(1);
            var arg2 = new IntNode(2);
            var result = node.SetValues(arg1, arg2);
            Assert.AreEqual(arg1, node[0]);
            Assert.AreEqual(arg2, node[1]);
            Assert.AreEqual(node, result);
        }

        #endregion

        [Test]
        public void BinaryOperator_Clone() {
            var node = Addition;
            var clone = node.Clone() as BinaryOperatorNode;

            Assert.AreEqual(node.Name, clone.Name);
            CollectionAssert.AreEqual(Enumerable.Repeat<Node>(null, 2), clone.Children);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

        #region Rendering
        [Test, TestCaseSource(nameof(BinaryOperator_Render) + "_Cases")]
        public string BinaryOperator_Render(string name, string symbol, int? arg1, int? arg2, bool outline) {
            var node = new BinaryOperatorNode(name, symbol);
            if (arg1.HasValue) node[0] = new IntNode(arg1.Value);
            if (arg2.HasValue) node[1] = new IntNode(arg2.Value);
            return node.Render(outline);
        }

        static IEnumerable<TestCaseData> BinaryOperator_Render_Cases {
            get {
                var prefix = nameof(BinaryOperator_Render);

                yield return new TestCaseData("Addition", "+", null, null, false)
                    .Returns("NULL+NULL")
                    .SetName(prefix + "_NoArgsWithoutOutline");

                yield return new TestCaseData("Addition", "+", null, null, true)
                    .Returns(String.Format("NULL{0}+{0}NULL", Environment.NewLine))
                    .SetName(prefix + "_NoArgsWithOutline");

                yield return new TestCaseData("Addition", "+", 1, 2, false)
                    .Returns("1+2")
                    .SetName(prefix + "_ArgsWithoutOutline");

                yield return new TestCaseData("Addition", "+", 1, 2, true)
                    .Returns(String.Format("1{0}+{0}2", Environment.NewLine))
                    .SetName(prefix + "_ArgsWithOutline");
            }

        }

        #endregion
    }
}
