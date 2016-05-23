using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class SheetNodeTest {

        const string defaultFormat = "{0}";

        #region Initialize
        
        [Test]
        public void SheetNode_Initialize() {
            var value = "hello";
            var node = new SheetNode(value);

            Assert.AreEqual("Literal", node.Name);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(defaultFormat, node.Format);
        }


        [Test, TestCaseSource(nameof(SheetNode_InitializeInvalidName) + "_Cases")]
        public void SheetNode_InitializeInvalidName(string name) {
            Assert.Throws<ArgumentException>(() =>
                new SheetNode(name));
        }

        static IEnumerable<TestCaseData> SheetNode_InitializeInvalidName_Cases {
            get {
                var prefix = nameof(SheetNode_InitializeInvalidName);

                yield return new TestCaseData(null).SetName(prefix + "_Null");
                yield return new TestCaseData("").SetName(prefix + "_Empty");
                yield return new TestCaseData("abcdefghijklmnopqrstuvwxyz123456")
                    .SetName(prefix + "_Over31Chars");
                //TODO: Add additional cases
            }
        }
        #endregion

        [Test]
        public void SheetNode_ChildrenEmpty() {
            var node = new SheetNode("Sheet1");
            CollectionAssert.IsEmpty(node.Children);
        }

        #region Render

        [Test, TestCaseSource(nameof(SheetNode_Render) + "_Cases")]
        public string SheetNode_Render(string value, bool outline) =>
            new SheetNode(value).Render(outline);

        static IEnumerable<TestCaseData> SheetNode_Render_Cases {
            get {
                var prefix = nameof(SheetNode_Render);

                yield return new TestCaseData("Sheet1", false)
                    .Returns("Sheet1")
                    .SetName(prefix + "_NoOutline");

                yield return new TestCaseData("Sheet1", true)
                    .Returns("Sheet1")
                    .SetName(prefix + "_Outline");
            }
        }
        #endregion

        [Test]
        public void SheetNode_Clone() {
            var node = new SheetNode("hello");
            var clone = node.Clone() as SheetNode;

            Assert.AreEqual(node.Name, clone.Name);
            Assert.AreEqual(node.Value, clone.Value);
            Assert.AreEqual(defaultFormat, clone.Format);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

        #region IsValidBookName

        [Test, TestCaseSource(nameof(SheetNode_IsValidName) + "_Cases")]
        public bool SheetNode_IsValidName(string name) => SheetNode.IsValidName(name);

        static IEnumerable<TestCaseData> SheetNode_IsValidName_Cases {
            get {
                var prefix = nameof(SheetNode_IsValidName);

                yield return new TestCaseData("Sheet1").Returns(true).SetName(prefix + "_Normal");
                yield return new TestCaseData("").Returns(false).SetName(prefix + "_Empty");
                yield return new TestCaseData(null).Returns(false).SetName(prefix + "_Null");
                yield return new TestCaseData("abcdefghijklmnopqrstuvwxyz123456")
                    .Returns(false).SetName(prefix + "_Over31Chars");
                //TODO: Add additional test cases

            }
        }

        #endregion
    }
}
