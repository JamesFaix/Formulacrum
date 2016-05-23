using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Formulacrum.Nodes.Test {

    [TestFixture]
    public class StringExtTest {

        #region Split
        [Test, TestCaseSource(nameof(Split_NullArgs) + "_Cases")]
        public void Split_NullArgs(string text, string delimiter) {
            Assert.Throws<ArgumentNullException>(() =>
                StringExt.Split(text, delimiter));
        }

        static IEnumerable<TestCaseData> Split_NullArgs_Cases {
            get {
                var prefix = nameof(Split_NullArgs_Cases);

                yield return new TestCaseData(null, ",")
                    .SetName(prefix + "_TextIsNull");
                yield return new TestCaseData("test", null)
                    .SetName(prefix + "_DelimiterIsNull");
            }
        }

        [Test, TestCaseSource(nameof(Split_Simple) + "_Cases")]
        public string[] Split_Simple(string text, string delimiter) => 
            StringExt.Split(text, delimiter);

        static IEnumerable<TestCaseData> Split_Simple_Cases {
            get {
                var prefix = "Split";

                yield return new TestCaseData("Hello", ",")
                    .Returns(new string[] { "Hello" })
                    .SetName(prefix + "_ReturnsSingleElementIfDelimiterNotFound");

                yield return new TestCaseData("Test,,,test", ",")
                    .Returns(new string[] { "Test", "", "", "test" })
                    .SetName(prefix + "ReturnsEmptyElementsIfDelimiterIsRepeated");

                yield return new TestCaseData("one,two,three", ",")
                    .Returns(new string[] { "one", "two", "three" })
                    .SetName(prefix + "_SplitsByDelimiter");

                yield return new TestCaseData("one, two , three", ",")
                    .Returns(new string[] { "one", " two ", " three" })
                    .SetName(prefix + "_ResultsIncludeLeadingOrTrailingWhitespace");
            }
        }

        #endregion

        #region ToDelimitedString
        [Test, TestCaseSource(nameof(ToDelimitedString_NullArgs) + "_Cases")]
        public void ToDelimitedString_NullArgs(IEnumerable<string> strings, string delimiter) {
            Assert.Throws<ArgumentNullException>(() =>
               StringExt.ToDelimitedString(strings, delimiter));
        }

        static IEnumerable<TestCaseData> ToDelimitedString_NullArgs_Cases {
            get {
                var prefix = nameof(ToDelimitedString_NullArgs_Cases);

                yield return new TestCaseData(null, ",")
                    .SetName(prefix + "_SequenceIsNull");
                yield return new TestCaseData(new[] { null, "b", "c" }, ",")
                    .SetName(prefix + "_SequenceContainsNull");
                yield return new TestCaseData(new[] { "a", "b", "c" }, null)
                    .SetName(prefix + "_DelimiterIsNull");
            }
        }

        [Test, TestCaseSource(nameof(ToDelimitedString_Simple) + "_Cases")]
        public string ToDelimitedString_Simple(IEnumerable<string> strings, string delimiter) =>
            StringExt.ToDelimitedString(strings, delimiter);

        static IEnumerable<TestCaseData> ToDelimitedString_Simple_Cases {
            get {
                var prefix = "ToDelimitedString";

                yield return new TestCaseData(new string[0], ",")
                    .Returns("")
                    .SetName(prefix + "ReturnsEmptyIfSequenceEmpty");

                yield return new TestCaseData(new string[] { "a", "b", "c" }, ",")
                    .Returns("a,b,c")
                    .SetName("JoinsElementsWithDelimiter");

                yield return new TestCaseData(new string[] { "a", "", "c" }, ",")
                    .Returns("a,,c")
                    .SetName("RepeatsDelimiterIfElementEmpty");
                
                yield return new TestCaseData(new string[] { "a", "b,c", "d" }, ",")
                    .Returns("a,b,c,d")
                    .SetName("IncludesDelimiterInstancesInElements");
            }
        }

        #endregion
    }
}
