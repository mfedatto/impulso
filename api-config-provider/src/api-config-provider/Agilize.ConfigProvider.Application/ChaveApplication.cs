using Agilize.ConfigProvider.Domain.Chave;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Application;

public class ChaveApplication : IChaveApplication
{
    public Task<PagedListWrapper<IChave>> BuscarChaves(
        Guid appId,
        DateTime vigenteEm,
        string? nome = null,
        int? idTipo = null,
        bool? lista = null,
        bool? permiteNulo = null,
        int? idChavePai = null,
        bool habilitado = true,
        int? skip = 0,
        int? limit = null)
    {
        throw new Http501NaoImplementadoException();
    }
}
