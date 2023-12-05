namespace Agilize.ConfigProvider.Domain.Configuracao;

public interface IConfiguracaoService
{
    Task<IEnumerable<IConfiguracaoChaveValor<dynamic>>> BuscarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null,
        int? skip = 0,
        int? limit = null);
    Task<int> ContarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null);
}
