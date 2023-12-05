namespace Agilize.ConfigProvider.WebApi.Controllers.Configuracao;

public struct GetConfiguracaoResponseModel<T>
{
    public string Chave { get; init; }
    public T Valor { get; init; }
    public bool Habilitado { get; init; }
}
