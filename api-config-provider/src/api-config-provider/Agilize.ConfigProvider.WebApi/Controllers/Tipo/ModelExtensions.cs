using Agilize.ConfigProvider.Domain.Tipo;

namespace Agilize.ConfigProvider.WebApi.Controllers.Tipo;

public static class ModelExtensions
{
    public static GetTipoResponseModel ToGetResponseModel(this ITipo tipo)
    {
        return new GetTipoResponseModel
        {
            Id = tipo.Id,
            Nome = tipo.Nome,
            Habilitado = tipo.Habilitado
        };
    }
}
