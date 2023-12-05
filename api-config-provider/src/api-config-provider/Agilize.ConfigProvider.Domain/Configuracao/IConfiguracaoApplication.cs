using Agilize.ConfigProvider.Domain.Wrappers;

namespace Agilize.ConfigProvider.Domain.Configuracao;

public interface IConfiguracaoApplication
{
    Task<PagedListWrapper<IConfiguracaoChaveValor<object>>> BuscarConfiguracoes(
        Guid appId,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null);
}
