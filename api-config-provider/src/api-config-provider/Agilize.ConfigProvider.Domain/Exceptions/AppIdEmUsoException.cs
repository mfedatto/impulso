using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Domain.Exceptions;

public class AppIdEmUsoException : Http409ConflitoException
{
    public AppIdEmUsoException() : base("AppId já em uso por uma aplicação.") { }
    
    public AppIdEmUsoException(Exception innerException) : base("AppId já em uso por uma aplicação.", innerException) { }
}
