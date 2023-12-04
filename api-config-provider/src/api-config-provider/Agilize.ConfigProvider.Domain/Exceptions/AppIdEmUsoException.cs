using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Domain.Exceptions;

public class AppIdEmUsoException : Http409ConflitoException
{
    private const string HttpExceptionMessage = "AppId já em uso por uma aplicação.";

    public AppIdEmUsoException() : base(HttpExceptionMessage) { }
    
    public AppIdEmUsoException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
