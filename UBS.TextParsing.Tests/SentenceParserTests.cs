using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UBS.TextParsing.Tests
{
    [TestFixture]
    public class SentenceParserTests
    {
        private readonly Tuple<string, Dictionary<string, int>>[] _testCases =
        {
            new Tuple<string, Dictionary<string, int>>("This is a statement, and so is this.",
                new Dictionary<string, int> 
                {
                   {"this", 2},
                    {"is", 2},
                    {"a", 1},
                    {"statement", 1},
                    {"and", 1},
                    {"so", 1},
                }),

            new Tuple<string, Dictionary<string, int>>("This is second statement,this time with no space!",
                new Dictionary<string, int> 
                {
                   {"this", 2},
                    {"is", 1},
                    {"time", 1},
                    {"second", 1},
                    {"statement", 1},
                    {"with", 1},
                    {"no", 1},
                    {"space", 1},
                }),

            new Tuple<string, Dictionary<string, int>>("Is this another\nstatement,\rnow with new line?!",
                new Dictionary<string, int> 
                {
                   {"this", 1},
                    {"is", 1},
                    {"another", 1},
                    {"statement", 1},
                    {"now", 1},
                    {"with", 1},
                    {"new", 1},
                    {"line", 1},
                }),

            new Tuple<string, Dictionary<string, int>>("Mendel;showed showed! this in in in several\\ ways: for/ example, by a back-cross.",
                new Dictionary<string, int> 
                {
                   {"mendel", 1},
                    {"showed", 2},
                    {"this", 1},
                    {"in", 3},
                    {"several", 1},
                    {"ways", 1},
                    {"for", 1},
                    {"example", 1},
                    {"by", 1},
                    {"a", 1},
                    {"back", 1},
                    {"cross", 1},
                }),
        };

        [Test]
        public void Parse_EmptyStringAsSentencePassed_ThrowsArgumentException()
        {
            var sp = new SentenceParser();

            Assert.Throws<ArgumentException>(() => sp.Parse(string.Empty));
        }

        [Test]
        public void Parse_NullAsSentencePassed_ThrowsArgumentNullException()
        {
            var sp = new SentenceParser();

            Assert.Throws<ArgumentNullException>(() => sp.Parse(null));
        }

        [Test, TestCaseSource("_testCases")]
        public void Parse_ArbitrarySentencePassed_ReturnsWordsWithCount(Tuple<string, Dictionary<string, int>> testCase)
        {
            var sp = new SentenceParser();

            var actualWordsCounts = sp.Parse(testCase.Item1);

            CollectionAssert.AreEquivalent(testCase.Item2, actualWordsCounts);
        }
    }
}
