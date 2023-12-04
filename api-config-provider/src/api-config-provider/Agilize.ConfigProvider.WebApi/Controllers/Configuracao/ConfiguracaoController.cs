using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.ConfigProvider.WebApi.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Agilize.ConfigProvider.WebApi.Controllers.Configuracao;

[Route(Rotas.Configuracoes)]
public class ConfiguracaoController : Controller
{
    [HttpGet(Rotas.ConfiguracoesGetConfiguracoes)]
    public async Task<ActionResult<PagedListWrapper<GetConfiguracaoResponseModel>>> Get_Index(
        [FromRoute(Name = ArgumentosNomeados.AppId)] Guid appId,
        [FromQuery(Name = ArgumentosNomeados.Id)] int? id = null,
        [FromQuery(Name = ArgumentosNomeados.Nome)] string? nome = null,
        [FromQuery(Name = ArgumentosNomeados.Habilitado)] bool? habilitado = null,
        [FromQuery(Name = ArgumentosNomeados.VigenteEm)] DateTime? vigenteEm = null,
        [FromQuery(Name = ArgumentosNomeados.Skip)] int? skip = 0,
        [FromQuery(Name = ArgumentosNomeados.Limit)] int? limit = null)
    {
        return Ok();
    }
}
