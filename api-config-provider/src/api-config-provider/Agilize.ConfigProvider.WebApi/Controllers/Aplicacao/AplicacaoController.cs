using Agilize.ConfigProvider.Domain.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Agilize.ConfigProvider.WebApi.Controllers.Aplicacao;

[Route("aplicacoes")]
public class AplicacaoController : Controller
{
    [HttpGet("")]
    public async Task<ActionResult<PagedListWrapper<GetIndexResponseModel[]>>> Get_Index(
        [FromQuery(Name = "app-id")] string? appId = null,
        [FromQuery(Name = "nome")] string? nome = null,
        [FromQuery(Name = "sigla")] string? sigla = null,
        [FromQuery(Name = "aka")] string? aka = null,
        [FromQuery(Name = "habilitado")] bool? habilitado = null,
        [FromQuery(Name = "vigente-em")] DateTime? vigenteEm = null,
        [FromQuery] int? skip = 0,
        [FromQuery] int? limit = null)
    {
        return Ok();
    }
}
