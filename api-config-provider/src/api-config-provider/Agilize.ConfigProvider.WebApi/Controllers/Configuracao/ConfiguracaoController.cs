using Agilize.ConfigProvider.Domain.Configuracao;
using Agilize.ConfigProvider.Domain.Exceptions;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.ConfigProvider.WebApi.Constants;
using Agilize.HttpExceptions;
using Microsoft.AspNetCore.Mvc;

namespace Agilize.ConfigProvider.WebApi.Controllers.Configuracao;

[Route(Rotas.Configuracoes)]
public class ConfiguracaoController : Controller
{
    private readonly IConfiguracaoApplication _application;

    public ConfiguracaoController(
        IConfiguracaoApplication application)
    {
        _application = application;
    }
    
    [HttpGet(Rotas.ConfiguracoesGetConfiguracoes)]
    public async Task<ActionResult<PagedListWrapper<GetConfiguracaoResponseModel<dynamic>>>> Get_Index(
        [FromRoute(Name = ArgumentosNomeados.AppId)] Guid appId,
        [FromQuery(Name = ArgumentosNomeados.VigenteEm)] DateTime? vigenteEm,
        [FromQuery(Name = ArgumentosNomeados.Nome)] string? nome = null,
        [FromQuery(Name = ArgumentosNomeados.IdTipo)] int? idTipo = null,
        [FromQuery(Name = ArgumentosNomeados.Habilitado)] bool? habilitado = null,
        [FromQuery(Name = ArgumentosNomeados.Skip)] int? skip = 0,
        [FromQuery(Name = ArgumentosNomeados.Limit)] int? limit = null)
    {
        if (!vigenteEm.HasValue) throw new DataDeVigenciaNaoInformadaException();

        Response.Headers.Append(CabecalhosNomeados.Competencia, vigenteEm.Value.ToString("yyyy-MM-dd"));
        
        return Ok((await _application.BuscarConfiguracoes(
                appId,
                vigenteEm.Value,
                idTipo,
                nome,
                habilitado,
                skip,
                limit))
            .Map(configuracao => configuracao.ToGetResponseModel()));
    }
}
