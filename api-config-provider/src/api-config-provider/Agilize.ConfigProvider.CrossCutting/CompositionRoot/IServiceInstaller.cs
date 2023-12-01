using Microsoft.Extensions.DependencyInjection;

namespace Agilize.ConfigProvider.CrossCutting.CompositionRoot;

public interface IServiceInstaller
{
    void Install(IServiceCollection services);
}
