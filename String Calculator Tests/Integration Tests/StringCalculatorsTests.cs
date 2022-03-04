using NUnit.Framework;
using String_Calculator_2._3;
using String_Calculator_2._3.Services;

namespace String_Calculator_Tests.Integration_Tests
{
    public class StringCalculatorsTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            var _numbers = new NumbersService(new ErrorHandlingService());
            var _calculations = new Calculations();
            var _splitService = new SplitService(new DelimitersService());

            _stringCalculator = new StringCalculator(_numbers, _calculations, _splitService);
        }

        [Test]
        public void Given_StringWithOneNumber_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "1";
            const int expected = -1;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithTwoNumbers_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "1,2";
            const int expected = -3;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithThreeNumbersSeperatedByNewLineAndDelimiter_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "1\n2,3";
            const int expected = -6;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithTwoNumberSeperatedByCustomDelimiter_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "##;\n1;23";
            const int expected = -24;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithThreeNumbersSeperatedByCustomDelimiterOfLengthThree_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "##***\n1***2***3";
            const int expected = -6;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithTwoLetters_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "a,b";
            const int expected = -1;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithThreeLetters_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "i,j,k";
            const int expected = -17;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithFlaggedDelimiters_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "<(>)##(*)\n1*2*3";
            const int expected = -6;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithMultipleFlaggedDelimiters_WhenSubtracting__ReturnsDifference()
        {
            //assert
            const string input = "<<>>##<$$$><###>\n5$$$6###7";
            const int expected = -18;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}
