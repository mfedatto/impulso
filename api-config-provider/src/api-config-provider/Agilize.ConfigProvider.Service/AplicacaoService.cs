using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Exceptions;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Service;

public class AplicacaoService : IAplicacaoService
{
    private readonly IAplicacaoRepository _repository;

    public AplicacaoService(IAplicacaoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<IAplicacao>> BuscarAplicacoes(
        Guid? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null)
    {
        return await _repository.BuscarAplicacoes(
            appId,
            nome,
            sigla,
            aka,
            habilitado,
            vigenteEm);
    }
    
    public async Task<int> ContarAplicacoes(
        Guid? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null)
    {
        return await _repository.ContarAplicacoes(
            appId,
            nome,
            sigla,
            aka,
            habilitado,
            vigenteEm);
    }
    
    public async Task IncluirAplicacao(IAplicacao aplicacao)
    {
        if (await _repository.BuscarAplicacao(aplicacao.AppId) is not null) throw new AppIdEmUsoException();
        
        await _repository.IncluirAplicacao(aplicacao);
    }

    public async Task<IAplicacao> BuscarAplicacao(Guid appId)
    {
        IAplicacao? result;
        
        try
        {
            result =  await _repository.BuscarAplicacao(appId);
            
            if (result is null) throw new AplicacaoNaoEncontradaException();
        }
        catch (InvalidOperationException ex)
        {
            throw new MaisDeUmAplicacaoEncontradaException(ex);
        }

        return result;
    }
}
