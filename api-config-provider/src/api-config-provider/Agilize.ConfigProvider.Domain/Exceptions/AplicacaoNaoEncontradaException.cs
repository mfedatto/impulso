using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Domain.Exceptions;

public class AplicacaoNaoEncontradaException : Http404NaoEncontradoException
{
    public AplicacaoNaoEncontradaException() : base("Aplicação não encontrada.") { }
    
    public AplicacaoNaoEncontradaException(Exception innerException) : base("Aplicação não encontrada.", innerException) { }
}
