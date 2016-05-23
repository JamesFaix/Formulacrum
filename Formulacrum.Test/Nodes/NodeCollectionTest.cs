using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class NodeCollectionTest {

        private NodeCollection Nodes => new NodeCollection(3, 5);

        #region Initialize

        [Test, TestCaseSource(nameof(NodeCollection_InitializeInvalidArgs) + "_Cases")]
        public void NodeCollection_InitializeInvalidArgs(int minCount, int maxCount) {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new NodeCollection(minCount, maxCount));
        }

        static IEnumerable<TestCaseData> NodeCollection_InitializeInvalidArgs_Cases {
            get {
                var prefix = nameof(NodeCollection_InitializeInvalidArgs);

                yield return new TestCaseData(-1, 5)
                    .SetName(prefix + "_MinNegative");

                yield return new TestCaseData(1, 0)
                    .SetName(prefix + "_MaxLessThanMin");

                yield return new TestCaseData(1, NodeCollection.CountLimit + 1)
                    .SetName(prefix + "_MaxOverLimit");
            }
        }

        [Test, TestCaseSource(nameof(NodeCollection_Initialize) + "_Cases")]
        public void NodeCollection_Initialize(int minCount, int maxCount) {
            var nodes = new NodeCollection(minCount, maxCount);

            Assert.AreEqual(minCount, nodes.MinCount);
            Assert.AreEqual(maxCount, nodes.MaxCount);
            Assert.AreEqual(minCount, nodes.Count);
        }

        static IEnumerable<TestCaseData> NodeCollection_Initialize_Cases {
            get {
                var prefix = nameof(NodeCollection_Initialize);

                yield return new TestCaseData(0, 0)
                    .SetName(prefix + "_ZeroArgs");

                yield return new TestCaseData(0, 5)
                    .SetName(prefix + "_ZeroToFiveArgs");
            }
        }

        #endregion

        #region Setters

        [Test]
        public void NodeCollection_SetIndex() {
            var value = new IntNode(3);
            var nodes = Nodes;
            nodes[2] = value;
            Assert.AreEqual(value, nodes[2]);
        }

        [Test, TestCaseSource(nameof(NodeCollection_SetIndexInvalidIndex) + "_Cases")]
        public void NodeCollection_SetIndexInvalidIndex(int index) {
            var nodes = Nodes;
            Assert.Throws<IndexOutOfRangeException>(() =>
                nodes[index] = null);
        }

        static IEnumerable<TestCaseData> NodeCollection_SetIndexInvalidIndex_Cases {
            get {
                var prefix = nameof(NodeCollection_SetIndexInvalidIndex);
                yield return new TestCaseData(-1)
                    .SetName(prefix + "_Negative");

                yield return new TestCaseData(3)
                    .SetName(prefix + "_TooHigh");
            }
        }

        #endregion

        //TODO : Finish tests for NodeCollection, GroupNode, FunctionNode, NodeExt, and Factories






















    }
}
