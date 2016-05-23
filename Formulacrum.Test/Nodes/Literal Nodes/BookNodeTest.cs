using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class BookNodeTest {

        const string defaultFormat = "{0}";

        #region Initialize
        
        [Test]
        public void BookNode_Initialize() {
            var value = "hello";
            var node = new BookNode(value);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(defaultFormat, node.Format);
        }

        [Test, TestCaseSource(nameof(BookNode_InitializeInvalidName) + "_Cases")]
        public void BookNode_InitializeInvalidName(string name) {
            Assert.Throws<ArgumentException>(() =>
                new BookNode(name));
        }

        static IEnumerable<TestCaseData> BookNode_InitializeInvalidName_Cases {
            get {
                var prefix = nameof(BookNode_InitializeInvalidName);

                yield return new TestCaseData(null).SetName(prefix + "_Null");
                yield return new TestCaseData("").SetName(prefix + "_Empty");

                //TODO: Add additional cases
            }
        }

        #endregion

        [Test]
        public void BookNode_ChildrenEmpty() {
            var node = new BookNode("Book1");
            CollectionAssert.IsEmpty(node.Children);
        }

        #region Render

        [Test, TestCaseSource(nameof(BookNode_Render) + "_Cases")]
        public string BookNode_Render(string value, bool outline) =>
            new BookNode(value).Render(outline);

        static IEnumerable<TestCaseData> BookNode_Render_Cases {
            get {
                var prefix = nameof(BookNode_Render);

                yield return new TestCaseData("Book1", false)
                    .Returns("Book1")
                    .SetName(prefix + "NoOutline");

                yield return new TestCaseData("Book1", true)
                    .Returns("Book1")
                    .SetName(prefix + "Outline");
              
            }
        }
        #endregion

        [Test]
        public void BookNode_Clone() {
            var node = new BookNode("Book1");
            var clone = node.Clone() as BookNode;

            Assert.AreEqual(node.Name, clone.Name);
            Assert.AreEqual(node.Value, clone.Value);
            Assert.AreEqual(node.Format, clone.Format);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

        #region IsValidBookName

        [Test, TestCaseSource(nameof(BookNode_IsValidName) + "_Cases")]
        public bool BookNode_IsValidName(string name) => BookNode.IsValidName(name);

        static IEnumerable<TestCaseData> BookNode_IsValidName_Cases {
            get {
                var prefix = nameof(BookNode_IsValidName);

                yield return new TestCaseData("Book1").Returns(true).SetName(prefix + "_Normal");
                yield return new TestCaseData("").Returns(false).SetName(prefix + "_Empty");
                yield return new TestCaseData(null).Returns(false).SetName(prefix + "_Null");
                //TODO: Add additional test cases

            }
        }

        #endregion
    }
}
