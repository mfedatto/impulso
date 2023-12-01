namespace Agilize.HttpExceptions;

public class Http500ErroInternoDoServidorException : Http5xxServerException
{
    public Http500ErroInternoDoServidorException() : this("HTTP 500 - Erro interno do servidor.") { }

    public Http500ErroInternoDoServidorException(string message) : base(message)
    {
        StatusCode = 500;
    }
}
