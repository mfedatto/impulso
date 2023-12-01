using Microsoft.AspNetCore.Builder;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot;

public interface IApplicationConfigurator
{
    IApplicationBuilder Configure(IApplicationBuilder app);
}
