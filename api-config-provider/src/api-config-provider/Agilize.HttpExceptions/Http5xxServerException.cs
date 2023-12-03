namespace Agilize.HttpExceptions;

public class Http5xxServerException : HttpException
{
    public Http5xxServerException() : this("HTTP 500 - Server error.") { }

    public Http5xxServerException(string message) : base(message)
    {
        StatusCode = 500;
    }
    
    protected Http5xxServerException(Exception innerException) : base("HTTP 500 - Server error.", innerException)
    {
        StatusCode = 500;
    }
    
    public Http5xxServerException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = 500;
    }
}
