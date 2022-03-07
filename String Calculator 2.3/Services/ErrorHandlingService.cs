using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3.Services
{
    public class ErrorHandlingService : IErrorHandling
    {
        public void ThrowNumbersTooLargeException(string bigNumbers)
        {
            string errorMessageTemplate = "You can't subtract numbers greater than 1000 :" + bigNumbers;

            throw new Exception(errorMessageTemplate);
        }
    }
}
