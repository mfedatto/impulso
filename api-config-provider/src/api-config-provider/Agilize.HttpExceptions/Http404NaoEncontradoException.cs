namespace Agilize.HttpExceptions;

public class Http404NaoEncontradoException : Http4xxClientException
{
    public Http404NaoEncontradoException() : this("HTTP 404 - Não encontrado.") { }
    
    public Http404NaoEncontradoException(string message) : base(message)
    {
        StatusCode = 404;
    }
    
    public Http404NaoEncontradoException(Exception innerException) : base("HTTP 404 - Não encontrado.", innerException)
    {
        StatusCode = 404;
    }
    
    public Http404NaoEncontradoException(string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = 404;
    }

}
