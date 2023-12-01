namespace Agilize.HttpExceptions;

public class Http5xxServerException : HttpException
{
    public Http5xxServerException() : this("HTTP 500 - Server error.") { }

    public Http5xxServerException(string message) : base(message)
    {
        StatusCode = 500;
    }
}
