using Agilize.ConfigProvider.Domain.Wrappers;

namespace Agilize.ConfigProvider.Domain.Configuracao;

public interface IConfiguracaoApplication
{
    Task<PagedListWrapper<IConfiguracaoChaveValor<object>>> BuscarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool habilitado = true,
        int? skip = 0,
        int? limit = null);
}
