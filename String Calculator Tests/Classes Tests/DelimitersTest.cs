using NUnit.Framework;
using String_Calculator_2._3.Services;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class DelimitersTest
    {
        private DelimitersService _delimitersService;

        [SetUp]
        public void Setup()
        {
            _delimitersService = new DelimitersService();
        }

        [Test]
        public void Given_StringWithFlaggedDelimiters_When_GettingDelimiters_Results_DelimitersList()
        {
            //arrange
            const string input = "<[>]##[&]\n870&45";
            var expected = new List<string>() { ",", "\n", "&"};

            //act
            var results = _delimitersService.GetDelimiters(input);

            //assert
            Assert.AreEqual(expected, results);

        }
    }
}
