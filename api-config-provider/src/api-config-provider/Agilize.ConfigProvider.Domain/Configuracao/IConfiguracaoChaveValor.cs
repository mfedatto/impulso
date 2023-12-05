using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Tipo;

namespace Agilize.ConfigProvider.Domain.Configuracao;

public interface IConfiguracaoChaveValor<T>
{
    string Chave { get; init; }
    T Valor { get; init; }
    bool Habilitado { get; init; }
}
