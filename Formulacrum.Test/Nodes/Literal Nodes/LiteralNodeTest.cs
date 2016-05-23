using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class LiteralNodeTest {

        #region Initialize
        [Test]
        public void LiteralNode_InitializeNullArgs() {
            var value = 1;
            string format = null;
            Node node;

            Assert.Throws<ArgumentNullException>(() =>
                node = new LiteralNode<int>(value, format));
        }

        [Test]
        public void LiteralIntNode_Initialize() {
            var value = 1;
            var format = "{0}";
            var node = new LiteralNode<int>(value, format);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(format, node.Format);
        }

        [Test]
        public void LiteralStringNode_Initialize() {
            var value = "hello";
            var format = "{0}";
            var node = new LiteralNode<string>(value, format);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(format, node.Format);
        }

        [Test]
        public void LiteralStringNode_InitializeNullValue() {
            string value = null;
            var format = "{0}";
            var node = new LiteralNode<string>(value, format);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(format, node.Format);
        }
        #endregion

        #region Children
        [Test]
        public void LiteralIntNode_ChildrenEmpty() {
            var node = new LiteralNode<int>(1, "{0}");
            CollectionAssert.IsEmpty(node.Children);
        }

        [Test]
        public void LiteralStringNode_ChildrenEmpty() {
            var node = new LiteralNode<string>("hello", "{0}");
            CollectionAssert.IsEmpty(node.Children);
        }
        #endregion

        #region Render
        [Test, TestCaseSource(nameof(LiteralIntNode_Render) + "_Cases")]
        public string LiteralIntNode_Render(int value, string format, bool outline) =>
            new LiteralNode<int>(value, format).Render(outline);

        static IEnumerable<TestCaseData> LiteralIntNode_Render_Cases {
            get {
                var prefix = nameof(LiteralIntNode_Render);

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

        [Test, TestCaseSource(nameof(LiteralStringNode_Render) + "_Cases")]
        public string LiteralStringNode_Render(string value, string format, bool outline) =>
            new LiteralNode<string>(value, format).Render(outline);

        static IEnumerable<TestCaseData> LiteralStringNode_Render_Cases {
            get {
                var prefix = nameof(LiteralStringNode_Render);

                yield return new TestCaseData("hello", "{0}", false)
                    .Returns("hello")
                    .SetName(prefix + "DefaultFormatNoOutline");

                yield return new TestCaseData("hello", "{0}", true)
                    .Returns("hello")
                    .SetName(prefix + "DefaultFormatOutline");

                var format = "He said, \"{0}\".";
                
                yield return new TestCaseData("hello", format, false)
                    .Returns("He said, \"hello\".")
                    .SetName(prefix + "CustomFormatNoOutline");

                yield return new TestCaseData("hello", format, true)
                    .Returns("He said, \"hello\".")
                    .SetName(prefix + "CustomFormatOutline");
            }
        }
        #endregion

        #region Clone

        [Test]
        public void LiteralIntNode_Clone() {
            var node = new LiteralNode<int>(1, "{0}");
            var clone = node.Clone() as LiteralNode<int>;

            Assert.AreEqual(node.Name, clone.Name);
            Assert.AreEqual(node.Value, clone.Value);
            Assert.AreEqual(node.Format, clone.Format);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }
        
        [Test]
        public void LiteralStringNode_Clone() {
            var node = new LiteralNode<string>("hello", "{0}");
            var clone = node.Clone() as LiteralNode<string>;

            Assert.AreEqual(node.Name, clone.Name);
            Assert.AreEqual(node.Value, clone.Value);
            Assert.AreEqual(node.Format, clone.Format);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

        #endregion

    }
}
