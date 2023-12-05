using Agilize.ConfigProvider.Domain.Configuracao;
using Agilize.ConfigProvider.Domain.Wrappers;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Application;

public class ConfiguracaoApplication : IConfiguracaoApplication
{
    private readonly IConfiguracaoService _service;

    public ConfiguracaoApplication(IConfiguracaoService service)
    {
        _service = service;
    }
    
    public async Task<PagedListWrapper<IConfiguracaoChaveValor<dynamic>>> BuscarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool habilitado = true,
        int? skip = 0,
        int? limit = null)
    {
        int total = await _service.ContarConfiguracoes(
            appId,
            vigenteEm,
            idTipo,
            nome,
            habilitado);

        if (total == 0)
            return Enumerable.Empty<IConfiguracaoChaveValor<dynamic>>()
                .WrapUp();
        
        return (await _service.BuscarConfiguracoes(
                appId,
                vigenteEm,
                idTipo,
                nome,
                habilitado))
            .WrapUp(skip ?? 0, limit, total);
    }
}
