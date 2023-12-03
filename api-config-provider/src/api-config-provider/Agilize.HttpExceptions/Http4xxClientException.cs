namespace Agilize.HttpExceptions;

public class Http4xxClientException : HttpException
{
    public Http4xxClientException() : this("HTTP 400 - Bad Request.") { }

    public Http4xxClientException(string message) : base(message)
    {
        StatusCode = 400;
    }
    
    public Http4xxClientException(Exception innerException) : base("HTTP 400 - Bad Request.", innerException)
    {
        StatusCode = 400;
    }
    
    public Http4xxClientException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = 400;
    }
}
