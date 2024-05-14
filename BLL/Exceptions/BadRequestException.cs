namespace BLL.Exceptions;
// custom exceptions for ExceptionHandler
public sealed class BadRequestException : Exception
{
    public BadRequestException(string message)
        : base(message)
    {
    }
}
