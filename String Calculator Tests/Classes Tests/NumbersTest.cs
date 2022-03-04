using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._3.Interfaces;
using String_Calculator_2._3.Services;
using System;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class NumbersTest
    {
        private IErrorHandling _errorHandlingMock;
        private NumbersService _numbersService;

        [SetUp]
        public void Setup()
        {
            _errorHandlingMock = Substitute.For<IErrorHandling>();
            _numbersService = new NumbersService(_errorHandlingMock);
        }

        [Test]
        public void Given_StringNumbersList_When_Converting_Returns_IntNumbersList()
        {
            //arrange
            var input = new List<string>() { "1", "7" };
            var expected = new List<int>() { 1, 7 };

            //act
            var results = _numbersService.ConvertStringsToNumbers(input);

            //aassert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_Characters_When_Converting_ReturnsIntNumbersList()
        {
            //arrange
            var input = new List<string>() { "d", "h" };
            var expected = new List<int>() { 3, 7 };

            //act
            var results = _numbersService.ConvertStringsToNumbers(input);

            //aassert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithLettersAndSpecialCharacter_When_Converting_ReturnsIntNumbersList()
        {
            //arrange
            var input = new List<string>() { "a", "b", "k" };
            var expected = new List<int>() { 0, 1, 0 };

            //act
            var results = _numbersService.ConvertStringsToNumbers(input);

            //aassert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithNumbersGreaterThanOneThousand_When_NumbersBiggerThanOneThousand_ReturnsException()
        {
            // arrange
            var input = new List<int> { 4000, 1000, 5000 };
            string expected = "You can't subtract numbers greater than 1000 : 4000 1000 5000 ";

            _errorHandlingMock.When(_numbers => _numbers.ThrowNumbersTooLargeException(Arg.Any<string>())).Do(x => throw new Exception(expected));

            //act
            var results = Assert.Throws<System.Exception>(() => _numbersService.CheckForNumbersGreaterThanOneThousand(input));

            //assert
            Assert.AreEqual(expected, results.Message);
        }
    }
}
