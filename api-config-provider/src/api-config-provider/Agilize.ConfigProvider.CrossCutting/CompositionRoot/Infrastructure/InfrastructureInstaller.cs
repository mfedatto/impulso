using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.MainDbContext;
using Agilize.ConfigProvider.Domain.Tipo;
using Agilize.ConfigProvider.Infrastructure.MainDbContext;
using Agilize.ConfigProvider.Infrastructure.MainDbContext.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot.Infrastructure;

public class InfrastructureInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();
        services.AddScoped<ITipoRepository, TipoRepository>();
    }
}
