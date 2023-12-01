namespace Agilize.HttpExceptions;

public class Http501NaoImplementadoException : Http5xxServerException
{
    public Http501NaoImplementadoException() : this("HTTP 501 - Não implementado.") { }

    public Http501NaoImplementadoException(string message) : base(message)
    {
        StatusCode = 501;
    }
}
