namespace Agilize.ConfigProvider.Domain.Configuracao;

public struct ConfiguracaoString : IConfiguracaoChaveValor<string>
{
    public string Chave { get; init; }
    public string Valor { get; init; }
    public bool Habilitado { get; init; }
}
