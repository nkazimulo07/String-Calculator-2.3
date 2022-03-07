using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3.Services
{
    public class DelimitersService : IDelimiters
    {
        public List<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string>() { Constants.Comma, Constants.NewLine };

            if (numbers.StartsWith(Constants.HashTags)  || numbers.StartsWith(Constants.DelimiterFlag))
            {
                delimiters.AddRange(CustomDelimiter(numbers));
            }

            return delimiters;
        }

        private List<string> CustomDelimiter(string numbers)
        {
            var delimiter = numbers.Substring(numbers.IndexOf(Constants.HashTags) + 2, numbers.IndexOf(Constants.NewLine) - 2);
            var delimiters = new List<string>();

            if ((delimiter.StartsWith(Constants.LeftSqureBracket) && delimiter.EndsWith(Constants.LeftSqureBracket)) || numbers.StartsWith(Constants.DelimiterFlag))
            {
                delimiters.AddRange(MultipleDelimiters(delimiter));
            }
            else
            {
                delimiters.Add(delimiter);
            }

            return delimiters;
        }

        private List<string> MultipleDelimiters(string delimiters)
        {
            char leftseperator = delimiters[0];
            char rightseperator = delimiters[delimiters.Length - 1];
            char[] charsToTrim = { leftseperator, rightseperator };
            string cleanDelimiter = delimiters.Trim(charsToTrim);
            string[] multipleDelimiter = cleanDelimiter.Split(new string[] { rightseperator.ToString(),leftseperator.ToString() }, StringSplitOptions.RemoveEmptyEntries);

            return multipleDelimiter.ToList();
        }
    }
}
