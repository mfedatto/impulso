using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Domain.Exceptions;

public class DataDeVigenciaNaoInformadaException : Http400RequisicaoInvalidaException
{
    private const string HttpExceptionMessage = "Data de vigência não informada.";

    public DataDeVigenciaNaoInformadaException() : base(HttpExceptionMessage) { }
    
    public DataDeVigenciaNaoInformadaException(Exception innerException) : base(HttpExceptionMessage, innerException) { }
}
