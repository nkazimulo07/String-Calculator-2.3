using NUnit.Framework;
using String_Calculator_2._3.Services;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class CalculationsTest
    {
        private Calculations _calculations;

        [SetUp]
        public void Setup()
        {
            _calculations = new Calculations();
        }

        [Test]
        public void Given__When__Returns()
        {
            //arrange
            var input = new List<int>() { 1, 40, 777};
            const int expected = -818;

            //act
            var results = _calculations.PerformCalculations(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}
