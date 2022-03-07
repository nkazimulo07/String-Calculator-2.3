namespace String_Calculator_2._3.Interfaces
{
    public interface IDelimiters
    {
        List<string> GetDelimiters(string numbers);
        List<string> CustomDelimiter(string numbers);
        List<string> MultipleDelimiters(string numbers);
    }
}
