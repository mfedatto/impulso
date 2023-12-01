using Agilize.ConfigProvider.CrossCutting.CompositionRoot;
using Agilize.ConfigProvider.WebApi.Middlewares;

namespace Agilize.ConfigProvider.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication Configure(this WebApplication app)
    {
        return (WebApplication)app.ConfigureApp()
            .UseMiddleware<HttpContextMiddleware>();
    }
}
