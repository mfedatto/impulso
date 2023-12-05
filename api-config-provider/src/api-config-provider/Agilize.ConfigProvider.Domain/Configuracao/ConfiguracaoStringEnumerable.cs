namespace Agilize.ConfigProvider.Domain.Configuracao;

public struct ConfiguracaoStringEnumerable : IConfiguracaoChaveValor<IEnumerable<string>>
{
    public string Chave { get; init; }
    public IEnumerable<string> Valor { get; init; }
    public bool Habilitado { get; init; }
}
