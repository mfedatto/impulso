using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        return app;
    }
}
