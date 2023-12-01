using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Infrastructure.MainDbContext.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot.Infrastructure;

public class InfrastructureInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();
    }
}
