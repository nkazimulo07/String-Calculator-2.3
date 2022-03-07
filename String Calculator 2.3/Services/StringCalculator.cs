using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3
{
    public class StringCalculator
    {
        private readonly INumbers _numbers;
        private readonly ICalculations _calculations;
        private readonly ISplit _split;

        public StringCalculator(INumbers numbers, ICalculations calculations, ISplit split)
        {
            _numbers = numbers;
            _calculations = calculations;
            _split = split;
        }

        public int Subtract(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numbersStringList = _split.SplitNumbers(numbers);
            var numbersIntergerList = _numbers.ConvertStringsToNumbers(numbersStringList);

            return _calculations.PerformCalculations(numbersIntergerList);
            
        }

       
    }
}