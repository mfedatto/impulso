using Agilize.ConfigProvider.Domain.Configuracao;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Service;

public class ConfiguracaoService : IConfiguracaoService
{
    private readonly IConfiguracaoRepository _repository;

    public ConfiguracaoService(IConfiguracaoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<IConfiguracaoChaveValor<dynamic>>> BuscarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null,
        int? skip = 0,
        int? limit = null)
    {
        return await _repository.BuscarConfiguracoes(
            appId,
            vigenteEm,
            idTipo,
            nome,
            habilitado,
            skip,
            limit);
    }

    public async Task<int> ContarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null)
    {
        return await _repository.ContarConfiguracoes(
            appId,
            vigenteEm,
            idTipo,
            nome,
            habilitado);
    }
}
