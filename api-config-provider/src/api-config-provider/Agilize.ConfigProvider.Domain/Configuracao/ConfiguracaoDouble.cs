namespace Agilize.ConfigProvider.Domain.Configuracao;

public struct ConfiguracaoDouble : IConfiguracaoChaveValor<double>
{
    public string Chave { get; init; }
    public double Valor { get; init; }
    public bool Habilitado { get; init; }
}
