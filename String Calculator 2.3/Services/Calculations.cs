using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3.Services
{
    public class Calculations : ICalculations
    {
        public int PerformCalculations(List<int> numbers)
        {
            var difference = 0;

            foreach (var number in numbers)
            {
                difference -= number;
            }

            return difference;
        }
    }
}
