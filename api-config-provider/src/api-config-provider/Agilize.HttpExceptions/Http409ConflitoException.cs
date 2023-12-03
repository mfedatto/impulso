namespace Agilize.HttpExceptions;

public class Http409ConflitoException : Http4xxClientException
{
    public Http409ConflitoException() : this("HTTP 409 - Conflito.") { }
    
    public Http409ConflitoException(string message) : base(message)
    {
        StatusCode = 409;
    }
    
    public Http409ConflitoException(Exception innerException) : base("HTTP 409 - Conflito.", innerException)
    {
        StatusCode = 409;
    }
    
    public Http409ConflitoException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = 409;
    }

}
