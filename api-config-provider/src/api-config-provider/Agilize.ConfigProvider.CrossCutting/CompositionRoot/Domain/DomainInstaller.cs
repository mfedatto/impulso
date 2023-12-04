using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Tipo;
using Microsoft.Extensions.DependencyInjection;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot.Domain;

public class DomainInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddSingleton<AplicacaoFactory>();
        services.AddSingleton<TipoFactory>();
    }
}
