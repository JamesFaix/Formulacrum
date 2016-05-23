using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class A1ReferenceNodeTest {

        #region Initialize

        [Test]
        public void A1Reference_InitializeDefault() {
            var node = new A1ReferenceNode();

            Assert.AreEqual(null, node.Top);
            Assert.AreEqual(null, node.Left);
            Assert.AreEqual(null, node.Bottom);
            Assert.AreEqual(null, node.Right);
            Assert.AreEqual(null, node.Sheet);
            Assert.AreEqual(null, node.Book);
            CollectionAssert.AreEqual(Enumerable.Repeat<Node>(null, 6), node.Children);
        }

        [Test]
        public void A1Reference_SetTopProperty() {
            var node = new A1ReferenceNode();
            var value = new IntNode(1);
            node.Top = value;

            Assert.AreEqual(value, node.Top);
            CollectionAssert.AreEqual(new Node[6] { null, null, value, null, null, null, }, node.Children);
        }

        [Test]
        public void A1Reference_SetLeftProperty() {
            var node = new A1ReferenceNode();
            var value = new IntNode(1);
            node.Left = value;

            Assert.AreEqual(value, node.Left);
            CollectionAssert.AreEqual(new Node[6] { null, null, null, value, null, null }, node.Children);
        }

        [Test]
        public void A1Reference_SetBottomProperty() {
            var node = new A1ReferenceNode();
            var value = new IntNode(1);
            node.Bottom = value;

            Assert.AreEqual(value, node.Bottom);
            CollectionAssert.AreEqual(new Node[6] { null, null, null, null, value, null }, node.Children);
        }

        [Test]
        public void A1Reference_SetRightProperty() {
            var node = new A1ReferenceNode();
            var value = new IntNode(1);
            node.Right = value;

            Assert.AreEqual(value, node.Right);
            CollectionAssert.AreEqual(new Node[6] { null, null, null, null, null, value }, node.Children);
        }

        [Test]
        public void A1Reference_SetBookProperty() {
            var node = new A1ReferenceNode();
            var value = new BookNode("Book1");
            node.Book = value;

            Assert.AreEqual(value, node.Book);
            CollectionAssert.AreEqual(new Node[6] { value, null, null, null, null, null }, node.Children);
        }

        [Test]
        public void A1Reference_SetSheetProperty() {
            var node = new A1ReferenceNode();
            var value = new SheetNode("Sheet1");
            node.Sheet = value;

            Assert.AreEqual(value, node.Sheet);
            CollectionAssert.AreEqual(new Node[6] { null, value, null, null, null, null }, node.Children);
        }

        [Test]
        public void A1Reference_SetCoordinates() {
            var node = new A1ReferenceNode();
            IntNode top = new IntNode(1), left = new IntNode(2),
                bottom = new IntNode(3), right = new IntNode(4);

            var result = node.SetCoordinates(top, left, bottom, right);

            Assert.AreEqual(node, result);
            CollectionAssert.AreEqual(new Node[6] { null, null, top, left, bottom, right }, node.Children);
        }

        [Test]
        public void A1Reference_SetBook() {
            var node = new A1ReferenceNode();
            var value = new BookNode("Book1");
            var result = node.SetBook(value);

            Assert.AreEqual(node, result);
            Assert.AreEqual(node.Book, value);
        }

        [Test]
        public void A1Reference_SetBookString() {
            var node = new A1ReferenceNode();
            var value = "Book1";
            var result = node.SetBook(value);

            Assert.AreEqual(node, result);
            Assert.AreEqual(node.Book.Value, value);
        }

        [Test]
        public void A1Reference_SetSheet() {
            var node = new A1ReferenceNode();
            var value = new SheetNode("Sheet1");
            var result = node.SetSheet(value);

            Assert.AreEqual(node, result);
            Assert.AreEqual(node.Sheet, value);
        }

        [Test]
        public void A1Reference_SetSheetstring() {
            var node = new A1ReferenceNode();
            var value = "Sheet1";
            var result = node.SetSheet(value);

            Assert.AreEqual(node, result);
            Assert.AreEqual(node.Sheet.Value, value);
        }

        #endregion

        [Test]
        public void A1Reference_Clone() {
            var node = new A1ReferenceNode();
            var clone = node.Clone() as A1ReferenceNode;

            Assert.AreEqual(node.Name, clone.Name);
            CollectionAssert.AreEqual(Enumerable.Repeat<Node>(null, 6), clone.Children);
            Assert.IsFalse(ReferenceEquals(node, clone));
        }

        #region Rendering

        [Test, TestCaseSource(nameof(A1Reference_BookAndSheetPrefix) + "_Cases")]
        public string A1Reference_BookAndSheetPrefix(string bookName, string sheetName) {
            var node = new A1ReferenceNode();
            if (sheetName != null) node.SetSheet(sheetName);
            if (bookName != null) node.SetBook(bookName);
            return node.BookAndSheetPrefix;
        }

        static IEnumerable<TestCaseData> A1Reference_BookAndSheetPrefix_Cases {
            get {
                var prefix = nameof(A1Reference_BookAndSheetPrefix);

                yield return new TestCaseData("Book1", "Sheet1")
                    .Returns("'[Book1]Sheet1'!")
                    .SetName(prefix + "_BookAndSheet");

                yield return new TestCaseData(null, "Sheet1")
                   .Returns("'Sheet1'!")
                   .SetName(prefix + "_SheetOnly");

                yield return new TestCaseData("Book1", null)
                   .Returns("")
                   .SetName(prefix + "_BookOnly");

                yield return new TestCaseData(null, null)
                   .Returns("")
                   .SetName(prefix + "_NoBookOrSheet");
            }
        }

        [Test, TestCaseSource(nameof(A1Reference_Coordinates) + "_Cases")]
        public string A1Reference_Coordinates(int? top, int? left, int? bottom, int? right) {
            var node = new A1ReferenceNode();
            if (top != null) node.Top = new IntNode(top.Value);
            if (left != null) node.Left = new IntNode(left.Value);
            if (bottom != null) node.Bottom = new IntNode(bottom.Value);
            if (right != null) node.Right = new IntNode(right.Value);
            return node.Coordinates;
        }

        static IEnumerable<TestCaseData> A1Reference_Coordinates_Cases {
            get {
                var prefix = nameof(A1Reference_Coordinates);

                yield return new TestCaseData(null, null, null, null)
                    .Returns("NULL")
                    .SetName(prefix + "_Empty");

                yield return new TestCaseData(1, null, null, null)
                   .Returns("1:1")
                   .SetName(prefix + "_TopOnly");

                yield return new TestCaseData(null, null, 3, null)
                   .Returns("3:3")
                   .SetName(prefix + "_BottomOnly");

                yield return new TestCaseData(null, 2, null, null)
                   .Returns("B:B")
                   .SetName(prefix + "_LeftOnly");

                yield return new TestCaseData(null, null, null, 4)
                  .Returns("D:D")
                  .SetName(prefix + "_RightOnly");

                yield return new TestCaseData(1, null, 3, null)
                   .Returns("1:3")
                   .SetName(prefix + "_TopBottom");

                yield return new TestCaseData(null, 2, null, 4)
                   .Returns("B:D")
                   .SetName(prefix + "_LeftRight");

                yield return new TestCaseData(1, 2, 3, null)
                   .Returns("B1:B3")
                   .SetName(prefix + "_TopBottomLeft");

                yield return new TestCaseData(1, null, 3, 4)
                   .Returns("D1:D3")
                   .SetName(prefix + "_TopBottomRight");

                yield return new TestCaseData(1, 2, null, 4)
                   .Returns("B1:D1")
                   .SetName(prefix + "_LeftRightTop");

                yield return new TestCaseData(null, 2, 3, 4)
                   .Returns("B3:D3")
                   .SetName(prefix + "_LeftRightBottom");

                yield return new TestCaseData(1, 2, 3, 4)
                   .Returns("B1:D3")
                   .SetName(prefix + "_TopBottomLeftRight");
            }
        }

        [Test, TestCaseSource(nameof(A1Reference_Render) + "_Cases")]
        public string A1Reference_Render(string bookName, string sheetName,
            int? top, int? left, int? bottom, int? right, bool outline) {
            var node = new A1ReferenceNode();
            if (bookName != null) node.SetBook(bookName);
            if (sheetName != null) node.SetSheet(sheetName);
            if (top != null) node.Top = new IntNode(top.Value);
            if (left != null) node.Left = new IntNode(left.Value);
            if (bottom != null) node.Bottom = new IntNode(bottom.Value);
            if (right != null) node.Right = new IntNode(right.Value);

            return node.Render(outline);
        }

        static IEnumerable<TestCaseData> A1Reference_Render_Cases {
            get {
                var prefix = nameof(A1Reference_Render);

                yield return new TestCaseData(null, null, null, null, null, null, false)
                    .Returns(Node.NullString)
                    .SetName(prefix + "_Empty");

                yield return new TestCaseData(null, "Sheet1", null, null, null, null, false)
                    .Returns("'Sheet1'!" + Node.NullString)
                    .SetName(prefix + "_SheetOnly");


                yield return new TestCaseData("Book1", null, null, null, null, null, false)
                    .Returns(Node.NullString)
                    .SetName(prefix + "_BookOnly");


                yield return new TestCaseData("Book1", "Sheet1", null, null, null, null, false)
                    .Returns("'[Book1]Sheet1'!" + Node.NullString)
                    .SetName(prefix + "_BookAndSheet");


                yield return new TestCaseData(null, null, 1, null, null, null, false)
                    .Returns("1:1")
                    .SetName(prefix + "_TopOnly");


                yield return new TestCaseData(null, null, null, null, 3, null, false)
                    .Returns("3:3")
                    .SetName(prefix + "_BottomOnly");


                yield return new TestCaseData(null, null, null, 2, null, null, false)
                    .Returns("B:B")
                    .SetName(prefix + "_LeftOnly");


                yield return new TestCaseData(null, null, null, null, null, 4, false)
                    .Returns("D:D")
                    .SetName(prefix + "_RightOnly");


                yield return new TestCaseData(null, null, 1, null, 3, null, false)
                    .Returns("1:3")
                    .SetName(prefix + "_TopBottom");


                yield return new TestCaseData(null, null, null, 2, null, 4, false)
                    .Returns("B:D")
                    .SetName(prefix + "_LeftRight");


                yield return new TestCaseData(null, null, 1, 2, null, null, false)
                    .Returns("B1")
                    .SetName(prefix + "_TopLeft");


                yield return new TestCaseData(null, null, null, null, 3, 4, false)
                    .Returns("D3")
                    .SetName(prefix + "_BottomRight");


                yield return new TestCaseData(null, null, 1, 2, 3, null, false)
                    .Returns("B1:B3")
                    .SetName(prefix + "_TopBottomLeft");


                yield return new TestCaseData(null, null, 1, null, 3, 4, false)
                    .Returns("D1:D3")
                    .SetName(prefix + "_TopBottomRight");


                yield return new TestCaseData(null, null, 1, 2, null, 4, false)
                    .Returns("B1:D1")
                    .SetName(prefix + "_LeftRightTop");


                yield return new TestCaseData(null, null, null, 2, 3, 4, false)
                    .Returns("B3:D3")
                    .SetName(prefix + "_LeftRightBottom");

                yield return new TestCaseData(null, null, 1, 2, 3, 4, false)
                    .Returns("B1:D3")
                    .SetName(prefix + "_TopBottomLeftRight");

                yield return new TestCaseData(null, null, 1, 2, 3, 4, true)
                    .Returns("B1:D3")
                    .SetName(prefix + "_TopBottomLeftRightOutline");

                yield return new TestCaseData("Book1", "Sheet1", 1, 2, 3, 4, false)
                    .Returns("'[Book1]Sheet1'!B1:D3")
                    .SetName(prefix + "_All");

                yield return new TestCaseData("Book1", "Sheet1", 1, 2, 3, 4, true)
                  .Returns("'[Book1]Sheet1'!B1:D3")
                  .SetName(prefix + "_AllOutline");

            }
        }


        #endregion
    }
}
