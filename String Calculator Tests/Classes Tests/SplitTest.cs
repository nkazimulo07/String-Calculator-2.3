using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._3.Interfaces;
using String_Calculator_2._3.Services;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class SplitTest
    {
        private IDelimiters _delimiters;
        private SplitService _splitService;

        [SetUp]
        public void SetUp()
        {
            _delimiters = Substitute.For<IDelimiters>();
            _splitService = new SplitService(_delimiters);
        }

        [Test]
        public void Given_StringWithTwoNumbers_When_Spliting_Return_StringNumbersList()
        {
            //arrange
            const string input = "8,70";
            var delimiters = new List<string>() { ",", "\n" };
            var expected = new List<string>() { "8", "70" };

            _delimiters.GetDelimiters(input).Returns(delimiters);

            //act
            var results = _splitService.SplitNumbers(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithFlaggedDelimiters_When_Spliting_Return_StringNumbersList()
        {
            //arrange
            const string input = "<[>]##[&]\n870&45";
            var delimiters = new List<string>() { ",", "\n", "&" };
            var expected = new List<string>() { "870", "45" };

            _delimiters.GetDelimiters(input).Returns(delimiters);

            //act
            var results = _splitService.SplitNumbers(input);

            //assert
            Assert.AreEqual(expected, results);

        }
    }
}
