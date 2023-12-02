using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.ConfigProvider.WebApi.Constants;
using Agilize.HttpExceptions;
using Microsoft.AspNetCore.Mvc;

namespace Agilize.ConfigProvider.WebApi.Controllers.Aplicacao;

[Route(RouteTemplate.Aplicacoes)]
public class AplicacaoController : Controller
{
    private readonly IAplicacaoApplication _application;
    
    public AplicacaoController(IAplicacaoApplication application)
    {
        _application = application;
    }
    
    [HttpGet(RouteTemplate.AplicacoesGetAplicacoes)]
    public async Task<ActionResult<PagedListWrapper<GetAplicacoesResponseModel>>> Get_Index(
        [FromQuery(Name = NameFromQuery.AppId)] string? appId = null,
        [FromQuery(Name = NameFromQuery.Nome)] string? nome = null,
        [FromQuery(Name = NameFromQuery.Sigla)] string? sigla = null,
        [FromQuery(Name = NameFromQuery.Aka)] string? aka = null,
        [FromQuery(Name = NameFromQuery.Habilitado)] bool? habilitado = null,
        [FromQuery(Name = NameFromQuery.VigenteEm)] DateTime? vigenteEm = null,
        [FromQuery(Name = NameFromQuery.Skip)] int? skip = 0,
        [FromQuery(Name = NameFromQuery.Limit)] int? limit = null)
    {
        return Ok(await _application.ObterListaDeAplicacoes(
            appId,
            nome,
            sigla,
            aka,
            habilitado,
            vigenteEm,
            skip,
            limit));
    }
    
    [HttpPost(RouteTemplate.AplicacoesPostAplicacao)]
    public async Task<ActionResult<PostAplicacaoResponseModel>> Post_Index(
        [FromBody] PostAplicacaoRequestModel requestModel)
    {
        throw new Http501NaoImplementadoException();
    }
}
