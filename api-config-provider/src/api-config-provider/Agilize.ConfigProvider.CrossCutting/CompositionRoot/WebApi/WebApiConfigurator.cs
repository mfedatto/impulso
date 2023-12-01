using Agilize.HttpExceptions;
using Microsoft.AspNetCore.Builder;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot.WebApi;

public class WebApiConfigurator : IApplicationConfigurator
{
    public IApplicationBuilder Configure(IApplicationBuilder app)
    {
        throw new Http501NaoImplementadoException();
    }
}
