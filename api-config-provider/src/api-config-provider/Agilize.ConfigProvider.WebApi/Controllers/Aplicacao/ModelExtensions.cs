using Agilize.ConfigProvider.Domain.Aplicacao;

namespace Agilize.ConfigProvider.WebApi.Controllers.Aplicacao;

public static class ModelExtensions
{
    public static GetIndexResponseModel ToGetIndexResponseModel(this IAplicacao aplicacao)
    {
        return new GetIndexResponseModel
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
