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
        bool habilitado = true,
        int? skip = 0,
        int? limit = null)
    {
        IEnumerable<IChave> chavesList = await _repository.BuscarChaves(
            appId,
            vigenteEm,
            idTipo,
            nome,
            habilitado,
            skip,
            limit);

        foreach (IChave chave in chavesList)
        {
            /*
             * | IdTipo | Tipo    |
             * | 3      | Número  |
             * | 5      | Texto   |
             * | 7      | Lógico  |
             * | 11     | Data    |
             * | 13     | Json    |
             * | 17     | Binário |
             */

            switch (chave.IdTipo)
            {
                case 5:
                    
                    break;
                case 3:
                case 7:
                case 11:
                case 13:
                case 17:
                default:
                    throw new Http501NaoImplementadoException();
            }
        }
        
        throw new Http501NaoImplementadoException();
    }

    public async Task<int> ContarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool habilitado = true)
    {
        return await _repository.ContarChaves(
            appId,
            vigenteEm,
            idTipo,
            nome,
            habilitado);
    }
}
