using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Service;

public class AplicacaoService : IAplicacaoService
{
    private readonly IAplicacaoRepository _repository;

    public AplicacaoService(IAplicacaoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<IAplicacao>> ObterListaDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null)
    {
        return await _repository.ObterListaDeAplicacoes(
            appId,
            nome,
            sigla,
            aka,
            habilitado,
            vigenteEm);
    }
    
    public async Task<int> ObterTotalDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null)
    {
        return await _repository.ObterTotalDeAplicacoes(
            appId,
            nome,
            sigla,
            aka,
            habilitado,
            vigenteEm);
    }
    
    public async Task<IAplicacao> IncluirAplicacao(IAplicacao aplicacao)
    {
        throw new Http501NaoImplementadoException();
    }
}
