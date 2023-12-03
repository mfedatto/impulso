namespace Agilize.ConfigProvider.Domain.Aplicacao;

public interface IAplicacaoService
{
    Task<IEnumerable<IAplicacao>> BuscarAplicacoes(
        Guid? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null);
    Task<int> ContarAplicacoes(
        Guid? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null);
    Task IncluirAplicacao(IAplicacao aplicacao);
    Task<IAplicacao> BuscarAplicacao(Guid appId);
}
