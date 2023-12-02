using Agilize.ConfigProvider.Domain.Aplicacao;

namespace Agilize.ConfigProvider.WebApi.Controllers.Aplicacao;

public static class ModelExtensions
{
    public static GetAplicacoesResponseModel ToGetIndexResponseModel(this IAplicacao aplicacao)
    {
        return new GetAplicacoesResponseModel
        {
            AppId = aplicacao.AppId,
            Nome = aplicacao.Nome,
            Sigla = aplicacao.Sigla,
            Aka = aplicacao.Aka,
            Habilitado = aplicacao.Habilitado,
            VigenteDe = aplicacao.VigenteDe,
            VigenteAte = aplicacao.VigenteAte
        };
    }
}
