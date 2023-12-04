using Agilize.ConfigProvider.Domain.Wrappers;

namespace Agilize.ConfigProvider.Domain.Tipo;

public interface ITipoApplication
{
    Task<PagedListWrapper<ITipo>> BuscarTipos(
        int? id = null,
        string? nome = null,
        bool? habilitado = null,
        int? skip = 0,
        int? limit = null);
    Task<ITipo> BuscarTipo(int id);
}
