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
                var numberToAddToList = 0;

                if (char.IsLetter(number[0]))
                {
                    numberToAddToList = ConvertCharacterToInt(char.Parse(number));
                }
                else if (char.IsDigit(number[0]))
                {
                    numberToAddToList = Math.Abs(Convert.ToInt32(number));
                }

                numbersList.Add(numberToAddToList);
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

        public int ConvertCharacterToInt(char character)
        {
            var number = character - Constants.Character;

            if (number > Constants.LettersMaximumValue)
            {
                return 0;
            }

            return number;
        }
    }
}
