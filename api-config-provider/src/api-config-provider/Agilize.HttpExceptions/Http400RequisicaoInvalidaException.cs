namespace Agilize.HttpExceptions;

public class Http400RequisicaoInvalidaException : Http4xxClientException
{
    public Http400RequisicaoInvalidaException() : this("HTTP 400 - Requisição inválida.") { }

    public Http400RequisicaoInvalidaException(string message) : base(message)
    {
        StatusCode = 400;
    }
}
