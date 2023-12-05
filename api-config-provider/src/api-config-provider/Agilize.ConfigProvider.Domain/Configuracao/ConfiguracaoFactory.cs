namespace Agilize.ConfigProvider.Domain.Configuracao;

public class ConfiguracaoFactory
{
    private IConfiguracaoChaveValor<T> Create<T, TT>(
        string chave,
        T valor,
        bool habilitado)
    where TT : IConfiguracaoChaveValor<T>, new()
    {
        return new TT
        {
            Chave = chave,
            Valor = valor,
            Habilitado = habilitado
        };
    }
    
    public IConfiguracaoChaveValor<string> Create(
        string chave,
        string valor,
        bool habilitado)
    {
        return Create<string, ConfiguracaoString>(
            chave,
            valor,
            habilitado);
    }
    
    public IConfiguracaoChaveValor<IEnumerable<string>> Create(
        string chave,
        IEnumerable<string> valor,
        bool habilitado)
    {
        return Create<IEnumerable<string>, ConfiguracaoStringEnumerable>(
            chave,
            valor,
            habilitado);
    }
}
