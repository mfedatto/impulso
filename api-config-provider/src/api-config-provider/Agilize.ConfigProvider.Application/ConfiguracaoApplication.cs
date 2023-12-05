using Agilize.ConfigProvider.Domain.Configuracao;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Application;

public class ConfiguracaoApplication : IConfiguracaoApplication
{
    public Task<PagedListWrapper<IConfiguracaoChaveValor<object>>> BuscarConfiguracoes(
        Guid appId,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null)
    {
        throw new Http501NaoImplementadoException();
    }
}
