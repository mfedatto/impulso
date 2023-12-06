using Agilize.ConfigProvider.Domain.Wrappers;

namespace Agilize.ConfigProvider.Domain.Chave;

public interface IChaveApplication
{
    Task<PagedListWrapper<IChave>> BuscarChaves(
        Guid appId,
        DateTime vigenteEm,
        string? nome = null,
        int? idTipo = null,
        bool? lista = null,
        bool? permiteNulo = null,
        int? idChavePai = null,
        bool habilitado = true,
        int? skip = 0,
        int? limit = null);
}
