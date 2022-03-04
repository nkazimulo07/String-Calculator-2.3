using NUnit.Framework;


namespace StringCalculator.Tests
{
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}