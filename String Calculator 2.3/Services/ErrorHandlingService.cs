using String_Calculator_2._3.Interfaces;

namespace String_Calculator_2._3.Services
{
    public class ErrorHandlingService : IErrorHandling
    {
        public void ThrowNumbersTooLargeException(string bigNumbers)
        {
            throw new Exception(Constants.errorMessageTemplate + bigNumbers);
        }
    }
}
