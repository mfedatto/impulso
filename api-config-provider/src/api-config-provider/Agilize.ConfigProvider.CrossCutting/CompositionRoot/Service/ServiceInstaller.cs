using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Tipo;
using Agilize.ConfigProvider.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot.Service;

public class ServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddScoped<IAplicacaoService, AplicacaoService>();
        services.AddScoped<ITipoService, TipoService>();
    }
}
