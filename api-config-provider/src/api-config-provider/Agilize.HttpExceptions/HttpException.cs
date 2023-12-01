namespace Agilize.HttpExceptions;

public class HttpException : Exception
{
    public int StatusCode { get; protected set; }

    public HttpException() : base("HTTP Exception.") { }

    public HttpException(string message) : base(message) { }
}
