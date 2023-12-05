namespace Agilize.ConfigProvider.Domain.Configuracao;

public struct ConfiguracaoDoubleEnumerable : IConfiguracaoChaveValor<IEnumerable<double>>
{
    public string Chave { get; init; }
    public IEnumerable<double> Valor { get; init; }
    public bool Habilitado { get; init; }
}
