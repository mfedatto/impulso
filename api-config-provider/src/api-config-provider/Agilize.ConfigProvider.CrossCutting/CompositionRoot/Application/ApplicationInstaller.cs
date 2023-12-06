using Agilize.ConfigProvider.Application;
using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Chave;
using Agilize.ConfigProvider.Domain.Tipo;
using Microsoft.Extensions.DependencyInjection;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot.Application;

public class ApplicationInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddScoped<IAplicacaoApplication, AplicacaoApplication>();
        services.AddScoped<ITipoApplication, TipoApplication>();
        services.AddScoped<IChaveApplication, ChaveApplication>();
    }
}
