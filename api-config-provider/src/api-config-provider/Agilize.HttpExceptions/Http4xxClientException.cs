namespace Agilize.HttpExceptions;

public class Http4xxClientException : HttpException
{
    public Http4xxClientException() : this("HTTP 400 - Bad Request.") { }

    public Http4xxClientException(string message) : base(message)
    {
        StatusCode = 400;
    }
}
