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
    
    public IConfiguracaoChaveValor<double> Create(
        string chave,
        double valor,
        bool habilitado)
    {
        return Create<double, ConfiguracaoDouble>(
            chave,
            valor,
            habilitado);
    }
    
    public IConfiguracaoChaveValor<IEnumerable<double>> Create(
        string chave,
        IEnumerable<double> valor,
        bool habilitado)
    {
        return Create<IEnumerable<double>, ConfiguracaoDoubleEnumerable>(
            chave,
            valor,
            habilitado);
    }
}
