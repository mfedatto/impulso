using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Exceptions;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Application;

public class AplicacaoApplication : IAplicacaoApplication
{
    private readonly IAplicacaoService _service;

    public AplicacaoApplication(IAplicacaoService service)
    {
        _service = service;
    }
    
    public async Task<PagedListWrapper<IAplicacao>> BuscarAplicacoes(
        Guid? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null)
    {
        int total = await _service.ContarAplicacoes(
            appId,
            nome,
            sigla,
            aka,
            habilitado,
            vigenteEm);

        if (total == 0)
            return Enumerable.Empty<IAplicacao>()
                .WrapUp();
        
        return (await _service.BuscarAplicacoes(
            appId,
            nome,
            sigla,
            aka,
            habilitado,
            vigenteEm,
            skip,
            limit))
            .WrapUp(skip ?? 0, limit, total);
    }
    
    public async Task IncluirAplicacao(IAplicacao aplicacao)
    {
        await _service.IncluirAplicacao(aplicacao);
    }
    
    public async Task<IAplicacao> BuscarAplicacaoPorId(Guid appId)
    {
        return await _service.BuscarAplicacaoPorId(appId);
    }
    
    public async Task AtualizarAplicacao(IAplicacao aplicacao)
    {
        if ((await _service.BuscarAplicacaoPorId(aplicacao.AppId)) is null)
            throw new AplicacaoNaoEncontradaException();

        await _service.AtualizarAplicacao(aplicacao);
    }
    
    public async Task ExcluirAplicacao(Guid appId)
    {
        if ((await _service.BuscarAplicacaoPorId(appId)) is null)
            throw new AplicacaoNaoEncontradaException();

        await _service.ExcluirAplicacao(appId);
    }
}
