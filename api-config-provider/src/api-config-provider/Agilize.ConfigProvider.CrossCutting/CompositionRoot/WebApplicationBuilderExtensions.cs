using Agilize.ConfigProvider.CrossCutting.CompositionRoot.Application;
using Agilize.ConfigProvider.CrossCutting.CompositionRoot.Infrastructure;
using Agilize.ConfigProvider.CrossCutting.CompositionRoot.Service;
using Agilize.ConfigProvider.CrossCutting.CompositionRoot.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot;

public static class WebApplicationBuilderExtensions
{
    private static IServiceCollection InstallServices<T>(this IServiceCollection services)
        where T : IServiceInstaller, new()
    {
        new T().Install(services);
        
        return services;
    }

    public static WebApplicationBuilder AddCompositionRoot(this WebApplicationBuilder builder)
    {
        builder.Services
            .InstallServices<InfrastructureInstaller>()
            .InstallServices<ServiceInstaller>()
            .InstallServices<ApplicationInstaller>()
            .InstallServices<WebApiInstaller>();
        
        return builder;
    }
}
