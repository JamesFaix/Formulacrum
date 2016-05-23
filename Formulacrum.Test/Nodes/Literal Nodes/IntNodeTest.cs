using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class IntNodeTest {

        #region Initialize
        [Test]
        public void IntNode_InitializeNullArgs() {
            var value = 1;
            string format = null;
            Node node;

            Assert.Throws<ArgumentNullException>(() =>
                node = new IntNode(value, format));
        }

        [Test]
        public void LiteralIntNode_InitializeWithFormat() {
            var value = 1;
            var format = "{0}";
            var node = new IntNode(value, format);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(format, node.Format);
        }

        [Test]
        public void LiteralIntNode_InitializeWithoutFormat() {
            var value = 1;
            var node = new IntNode(value);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual("{0}", node.Format);
        }

        #endregion

        [Test]
        public void IntNode_ChildrenEmpty() {
            var node = new IntNode(1, "{0}");
            CollectionAssert.IsEmpty(node.Children);
        }
        

        #region Render
        [Test, TestCaseSource(nameof(IntNode_Render) + "_Cases")]
        public string IntNode_Render(int value, string format, bool outline) =>
            new IntNode(value, format).Render(outline);

        static IEnumerable<TestCaseData> IntNode_Render_Cases {
            get {
                var prefix = nameof(IntNode_Render);

                yield return new TestCaseData(1, "{0}", false)
                    .Returns("1")
                    .SetName(prefix + "DefaultFormatNoOutline");

                yield return new TestCaseData(1, "{0}", true)
                    .Returns("1")
                    .SetName(prefix + "DefaultFormatOutline");

                yield return new TestCaseData(1, "${0:0.00}", false)
                    .Returns("$1.00")
                    .SetName(prefix + "CustomFormatNoOutline");

                yield return new TestCaseData(1, "${0:0.00}", true)
                    .Returns("$1.00")
                    .SetName(prefix + "CustomFormatOutline");
            }
        }

        #endregion

        [Test]
        public void IntNode_Clone() {
            var node = new IntNode(1, "{0}");
            var clone = node.Clone() as IntNode;

            Assert.AreEqual(node.Name, clone.Name);
            Assert.AreEqual(node.Value, clone.Value);
            Assert.AreEqual(node.Format, clone.Format);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

    }
}
