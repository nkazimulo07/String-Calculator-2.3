using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3.Services
{
    public class DelimitersService : IDelimiters
    {
        public List<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string>() { ",", Constants.NewLine };

            if (numbers.StartsWith(Constants.HashTags))
            {
                delimiters.AddRange(CustomDelimiter(numbers));
            }
            else if (numbers.StartsWith(Constants.Flag))
            {
                delimiters.AddRange(FlaggedDelimiters(numbers));
            }

            return delimiters;
        }

        public List<string> CustomDelimiter(string numbers)
        {
            var delimiter = numbers.Substring(numbers.IndexOf(Constants.HashTags) + 2, numbers.IndexOf(Constants.NewLine) - 2);
            var delimiters = new List<string>();

            if (delimiter.StartsWith(Constants.LeftSqureBracket) && delimiter.EndsWith(Constants.LeftSqureBracket))
            {
                delimiters.AddRange(MultipleDelimiters(delimiter));
            }
            else
            {
                delimiters.Add(delimiter);
            }

            return delimiters;
        }

        public List<string> FlaggedDelimiters(string number)
        {
            var delimiter = number.Substring(number.IndexOf(Constants.HashTags) + 2, number.IndexOf(Constants.NewLine) - 6);
            char leftseperator = number[1];
            char rightseperator = number[number.IndexOf(Constants.HashTags) - 1];
            char[] charsToTrim = { leftseperator, rightseperator };
            string cleanDelimiter = delimiter.Trim(charsToTrim);
            string[] flaggedDelimiter = cleanDelimiter.Split(new string[] { rightseperator.ToString(), leftseperator.ToString() }, StringSplitOptions.RemoveEmptyEntries);

            return flaggedDelimiter.ToList();
        }

        public List<string> MultipleDelimiters(string delimiters)
        {
            char[] charsToTrim = { Constants.LeftSqureBracket, Constants.RightSqureBracket };
            string cleanDelimiter = delimiters.Trim(charsToTrim);
            string[] multipleDelimiter = cleanDelimiter.Split(new string[] { Constants.SquareBrackets }, StringSplitOptions.RemoveEmptyEntries);

            return multipleDelimiter.ToList();
        }
    }
}
