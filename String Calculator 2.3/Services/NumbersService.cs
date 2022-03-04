using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3.Services
{
    public class NumbersService : INumbers
    {
        private readonly IErrorHandling _errorHandling;

        public NumbersService(IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;
        }

        public List<int> ConvertStringsToNumbers(List<string> numbers)
        {
            var numbersList = new List<int>();

            foreach (var number in numbers)
            {
                var temporalNumber = 0;

                if (char.IsLetter(number[0]))
                {
                    temporalNumber = ConvertCharacterToInt(char.Parse(number));
                }
                else if (char.IsDigit(number[0]))
                {
                    temporalNumber = Math.Abs(Convert.ToInt32(number));
                }

                numbersList.Add(temporalNumber);
            }

            CheckForNumbersGreaterThanOneThousand(numbersList);

            return numbersList;
        }

        public void CheckForNumbersGreaterThanOneThousand(List<int> numbersList)
        {
            var bigNumbers = "";

            foreach (var number in numbersList)
            {
                if (number > Constants.MaximumNumber)
                {
                    bigNumbers = number + " ";
                }
            }

            if (!string.IsNullOrEmpty(bigNumbers))
            {
                _errorHandling.ThrowNumbersTooLargeException(bigNumbers);
            }
        }

        public int ConvertCharacterToInt(char alphebet)
        {
            var number = char.ToUpper(alphebet) - 65;

            if (number > Constants.BigNumber)
            {
                return 0;
            }

            return number;
        }
    }
}
