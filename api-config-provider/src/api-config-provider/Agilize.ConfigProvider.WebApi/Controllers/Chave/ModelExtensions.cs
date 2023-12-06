using Agilize.ConfigProvider.Domain.Chave;

namespace Agilize.ConfigProvider.WebApi.Controllers.Chave;

public static class ModelExtensions
{
    public static GetChaveResponseModel ToGetResponseModel(this IChave chave)
    {
        return new GetChaveResponseModel
        {
            Id = chave.Id,
            AppId = chave.AppId,
            Nome = chave.Nome,
            IdTipo = chave.IdTipo,
            Lista = chave.Lista,
            PermiteNulo = chave.PermiteNulo,
            IdChavePai = chave.IdChavePai,
            Habilitado = chave.Habilitado
        };
    }
}
