using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class StringNodeTest {

        const string defaultFormat = "\"{0}\"";

        #region Initialize
        
        [Test]
        public void StringNode_InitializeWithFormat() {
            var value = "hello";
            var format = "{0}";
            var node = new StringNode(value, format);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(format, node.Format);
        }

        [Test]
        public void StringNode_InitializeWithoutFormat() {
            var value = "hello";
            var node = new StringNode(value);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(defaultFormat, node.Format);
        }

        [Test]
        public void StringNode_InitializeNullValue() {
            string value = null;
            var format = "{0}";
            var node = new StringNode(value, format);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(format, node.Format);
        }

        [Test]
        public void StringNode_InitializeNullFormat() {
            var value = "hello";
            string format = null;

            var node = new StringNode(value, format);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(defaultFormat, node.Format);
        }
        #endregion

        [Test]
        public void StringNode_ChildrenEmpty() {
            var node = new StringNode("hello", "{0}");
            CollectionAssert.IsEmpty(node.Children);
        }

        #region Render
      
        [Test, TestCaseSource(nameof(StringNode_Render) + "_Cases")]
        public string StringNode_Render(string value, string format, bool outline) =>
            new StringNode(value, format).Render(outline);

        static IEnumerable<TestCaseData> StringNode_Render_Cases {
            get {
                var prefix = nameof(StringNode_Render);

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
        
        [Test]
        public void StringNode_Clone() {
            var node = new StringNode("hello", "{0}");
            var clone = node.Clone() as StringNode;

            Assert.AreEqual(node.Name, clone.Name);
            Assert.AreEqual(node.Value, clone.Value);
            Assert.AreEqual(node.Format, clone.Format);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

    }
}
