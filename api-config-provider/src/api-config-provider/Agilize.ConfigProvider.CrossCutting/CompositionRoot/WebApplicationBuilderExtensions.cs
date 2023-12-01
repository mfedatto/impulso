using Agilize.ConfigProvider.CrossCutting.CompositionRoot.Application;
using Agilize.ConfigProvider.CrossCutting.CompositionRoot.Infrastructure;
using Agilize.ConfigProvider.CrossCutting.CompositionRoot.WebApi;
using Microsoft.AspNetCore.Builder;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddCompositionRoot(this WebApplicationBuilder builder)
    {
        new InfrastructureInstaller().Install(builder.Services);
        new ApplicationInstaller().Install(builder.Services);
        new WebApiInstaller().Install(builder.Services);
        
        return builder;
    }
}
