namespace Agilize.HttpExceptions;

public class HttpException : Exception
{
    public int StatusCode { get; protected init; }

    protected HttpException() : base("HTTP Exception.") { }

    protected HttpException(string message) : base(message) { }

    protected HttpException(Exception innerException) : base("HTTP Exception.", innerException) { }
    
    protected HttpException(string message, Exception innerException) : base(message, innerException) { }
}
