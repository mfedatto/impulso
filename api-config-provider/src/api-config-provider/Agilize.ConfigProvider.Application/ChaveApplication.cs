using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Chave;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Application;

public class ChaveApplication : IChaveApplication
{
    private readonly IChaveService _service;
    private readonly IAplicacaoService _aplicacaoService;

    public ChaveApplication(
        IChaveService service,
        IAplicacaoService aplicacaoService)
    {
        _service = service;
        _aplicacaoService = aplicacaoService;
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

        if (0.Equals(total)) return Enumerable.Empty<IChave>().WrapUp();
        
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

    public async Task<bool> AplicacaoExiste(
        Guid appId)
    {
        return (await _aplicacaoService.BuscarAplicacaoPorId(appId)) is not null;
    }

    public async Task<IChave> BuscarChavePorId(
        Guid appId,
        int id,
        DateTime vigenteEm)
    {
        return await _service.BuscarChavePorId(
            appId,
            id,
            vigenteEm);
    }
}
