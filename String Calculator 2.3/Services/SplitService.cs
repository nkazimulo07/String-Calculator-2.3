using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3.Services
{
    public class SplitService : ISplit
    {
        private readonly IDelimiters _delimiters;

        public SplitService(IDelimiters delimiters)
        {
            _delimiters = delimiters;
        }

        public List<string> SplitNumbers(string numbers)
        {
            var delimiters = _delimiters.GetDelimiters(numbers);

            if (numbers.StartsWith(Constants.HashTags) || numbers.StartsWith(Constants.DelimiterFlag))
            {
                numbers = numbers.Substring(numbers.LastIndexOf(Constants.NewLine) + 1);

            }

            string[] numbersArray = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);

            return numbersArray.ToList();
        }
    }
}
