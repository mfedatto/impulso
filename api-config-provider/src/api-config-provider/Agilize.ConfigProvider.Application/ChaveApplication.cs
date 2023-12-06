using Agilize.ConfigProvider.Domain.Chave;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Application;

public class ChaveApplication : IChaveApplication
{
    private readonly IChaveService _service;

    public ChaveApplication(
        IChaveService service)
    {
        _service = service;
    }
    
    public async Task<PagedListWrapper<IChave>> BuscarChaves(
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
        int total = await _service.ContarChaves(
            appId,
            vigenteEm,
            nome,
            idTipo,
            lista,
            permiteNulo,
            idChavePai,
            habilitado);

        if (total == 0)
            return Enumerable.Empty<IChave>()
                .WrapUp();
        
        return (await _service.BuscarChaves(
                appId,
                vigenteEm,
                nome,
                idTipo,
                lista,
                permiteNulo,
                idChavePai,
                habilitado,
                skip,
                limit))
            .WrapUp(skip ?? 0, limit, total);
    }
}
