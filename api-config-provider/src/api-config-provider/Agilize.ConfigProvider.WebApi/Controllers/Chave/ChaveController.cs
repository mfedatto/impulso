using Agilize.ConfigProvider.Domain.Chave;
using Agilize.ConfigProvider.Domain.Exceptions;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.ConfigProvider.WebApi.Constants;
using Agilize.HttpExceptions;
using Microsoft.AspNetCore.Mvc;

namespace Agilize.ConfigProvider.WebApi.Controllers.Chave;

[Route(Rotas.Chaves)]
public class ChaveController : Controller
{
    private readonly IChaveApplication _application;

    public ChaveController(
        IChaveApplication application)
    {
        _application = application;
    }
    
    [HttpGet(Rotas.ChavesGetChaves)]
    public async Task<ActionResult<PagedListWrapper<GetChaveResponseModel>>> Get_Index(
        [FromRoute(Name = ArgumentosNomeados.AppId)] Guid appId,
        [FromQuery(Name = ArgumentosNomeados.VigenteEm)] DateTime? vigenteEm,
        [FromQuery(Name = ArgumentosNomeados.Nome)] string? nome = null,
        [FromQuery(Name = ArgumentosNomeados.IdTipo)] int? idTipo = null,
        [FromQuery(Name = ArgumentosNomeados.Lista)] bool? lista = null,
        [FromQuery(Name = ArgumentosNomeados.PermiteNulo)] bool? permiteNulo = null,
        [FromQuery(Name = ArgumentosNomeados.IdPai)] int? idChavePai = null,
        [FromQuery(Name = ArgumentosNomeados.Habilitado)] bool habilitado = true,
        [FromQuery(Name = ArgumentosNomeados.Skip)] int? skip = 0,
        [FromQuery(Name = ArgumentosNomeados.Limit)] int? limit = null)
    {
        vigenteEm = vigenteEm ?? DateTime.Now;
        
        Response.Headers.Append(CabecalhosNomeados.VigenteEm, vigenteEm.Value.ToString("yyyy-MM-dd"));
        
        return Ok((await _application.BuscarChaves(
                appId,
                vigenteEm.Value,
                nome,
                idTipo,
                lista,
                permiteNulo,
                idChavePai,
                habilitado,
                skip,
                limit))
            .Map<IChave, GetChaveResponseModel>(chave => chave.ToGetResponseModel()));
    }
    
    [HttpGet(Rotas.ChavesGetChave)]
    public async Task<ActionResult<GetChaveResponseModel>> Get_ById(
        [FromRoute(Name = ArgumentosNomeados.AppId)] Guid appId,
        [FromRoute(Name = ArgumentosNomeados.Id)] int id,
        [FromQuery(Name = ArgumentosNomeados.VigenteEm)] DateTime? vigenteEm)
    {
        if (!await _application.AplicacaoExiste(appId)) throw new AplicacaoNaoEncontradaException();
        
        vigenteEm = vigenteEm ?? DateTime.Now;
        
        Response.Headers.Append(CabecalhosNomeados.VigenteEm, vigenteEm.Value.ToString("yyyy-MM-dd"));
        
        return Ok((await _application.BuscarChavePorId(
                appId,
                id,
                vigenteEm.Value))
            .ToGetResponseModel());
    }
}
