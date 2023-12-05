using Agilize.ConfigProvider.Domain.Configuracao;

namespace Agilize.ConfigProvider.WebApi.Controllers.Configuracao;

public static class ModelExtensions
{
    public static GetConfiguracaoResponseModel<T> ToGetResponseModel<T>(this IConfiguracaoChaveValor<T> configuracao)
    {
        return new GetConfiguracaoResponseModel<T>
        {
            Chave = configuracao.Chave,
            Valor = configuracao.Valor,
            Habilitado = configuracao.Habilitado
        };
    }
}
