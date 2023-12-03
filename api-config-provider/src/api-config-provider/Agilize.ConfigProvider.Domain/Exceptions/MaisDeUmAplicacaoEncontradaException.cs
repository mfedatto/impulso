using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Domain.Exceptions;

public class MaisDeUmAplicacaoEncontradaException : Http409ConflitoException
{
    public MaisDeUmAplicacaoEncontradaException() : base("Mais de uma aplicação encontrada.") { }
    
    public MaisDeUmAplicacaoEncontradaException(Exception innerException) : base("Mais de uma aplicação encontrada.", innerException) { }
}
