using Agilize.ConfigProvider.Domain.Chave;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Service;

public class ChaveService : IChaveService
{
    private readonly IChaveRepository _repository;

    public ChaveService(IChaveRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<IChave>> BuscarChaves(
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
        return await _repository.BuscarChaves(
            appId,
            vigenteEm,
            nome,
            idTipo,
            lista,
            permiteNulo,
            idChavePai,
            habilitado,
            skip,
            limit);
    }

    public async Task<int> ContarChaves(
        Guid appId,
        DateTime vigenteEm,
        string? nome = null,
        int? idTipo = null,
        bool? lista = null,
        bool? permiteNulo = null,
        int? idChavePai = null,
        bool habilitado = true)
    {
        return await _repository.ContarChaves(
            appId,
            vigenteEm,
            nome,
            idTipo,
            lista,
            permiteNulo,
            idChavePai,
            habilitado);
    }
}
