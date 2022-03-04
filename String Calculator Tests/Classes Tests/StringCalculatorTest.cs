using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._3;
using String_Calculator_2._3.Interfaces;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;
        private INumbers _numbersMock;
        private ICalculations _calculationsMock;
        private ISplit _splitMock;

        [SetUp]
        public void Setup()
        {
            _numbersMock = Substitute.For<INumbers>();
            _calculationsMock = Substitute.For<ICalculations>();
            _splitMock = Substitute.For<ISplit>();
            _stringCalculator = new StringCalculator(_numbersMock, _calculationsMock, _splitMock);
        }

        [Test]
        public void Given_EmptyString_When_Subtracting_Results_Zero()
        {
            //arrange 
            const string input = "";
            const int expected = 0;

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithOneNumber_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "1";
            const int expected = -1;
            var numbersStringList = new List<string>() { "1" };
            var numbersIntergerList = new List<int>() { 1 };

            _splitMock.SplitNumbers(input).Returns(numbersStringList);
            _numbersMock.ConvertStringsToNumbers(numbersStringList).Returns(numbersIntergerList);
            _calculationsMock.PerformCalculations(numbersIntergerList).Returns(expected);

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithTwoNumbers_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "1,2";
            const int expected = -3;
            var numbersStringList = new List<string>() { "1", "2" };
            var numbersIntergerList = new List<int>() { 1, 2 };

            _splitMock.SplitNumbers(input).Returns(numbersStringList);
            _numbersMock.ConvertStringsToNumbers(numbersStringList).Returns(numbersIntergerList);
            _calculationsMock.PerformCalculations(numbersIntergerList).Returns(expected);

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithNewLineAsDelimiter_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "1\n2,3";
            const int expected = -6;
            var numbersStringList = new List<string>() { "1", "2", "3" };
            var numbersIntergerList = new List<int>() { 1, 2, 3 };

            _splitMock.SplitNumbers(input).Returns(numbersStringList);
            _numbersMock.ConvertStringsToNumbers(numbersStringList).Returns(numbersIntergerList);
            _calculationsMock.PerformCalculations(numbersIntergerList).Returns(expected);

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithLetters_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "a,j,k,%";
            const int expected = -10;
            var numbersStringList = new List<string>() { "1", "2" };
            var numbersIntergerList = new List<int>() { 1, 2 };

            _splitMock.SplitNumbers(input).Returns(numbersStringList);
            _numbersMock.ConvertStringsToNumbers(numbersStringList).Returns(numbersIntergerList);
            _calculationsMock.PerformCalculations(numbersIntergerList).Returns(expected);

            //act
            var results = _stringCalculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}