namespace Agilize.HttpExceptions;

public class Http500ErroInternoDoServidorException : Http5xxServerException
{
    public Http500ErroInternoDoServidorException() : this("HTTP 500 - Erro interno do servidor.") { }

    public Http500ErroInternoDoServidorException(string message) : base(message)
    {
        StatusCode = 500;
    }
    
    public Http500ErroInternoDoServidorException(Exception innerException) : base("HTTP 500 - Erro interno do servidor.", innerException)
    {
        StatusCode = 500;
    }
    
    public Http500ErroInternoDoServidorException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = 500;
    }
}
