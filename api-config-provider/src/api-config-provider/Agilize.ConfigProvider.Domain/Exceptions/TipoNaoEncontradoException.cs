using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Domain.Exceptions;

public class TipoNaoEncontradoException : Http404NaoEncontradoException
{
    private const string HttpExceptionMessage = "Tipo não encontrado.";

    public TipoNaoEncontradoException() : base(HttpExceptionMessage) { }
    
    public TipoNaoEncontradoException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
