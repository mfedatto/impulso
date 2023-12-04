using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Domain.Exceptions;

public class MaisDeUmAplicacaoEncontradaException : Http409ConflitoException
{
    private const string HttpExceptionMessage = "Mais de uma aplicação encontrada.";

    public MaisDeUmAplicacaoEncontradaException() : base(HttpExceptionMessage) { }
    
    public MaisDeUmAplicacaoEncontradaException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
